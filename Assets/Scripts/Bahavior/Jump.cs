using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MovementBehavior
{
    [Header("Animations")]
    [SerializeField] GameObject spriteObject;
    [SerializeField] private Animator anim;
    [Header("Stats")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] float jumpforce;
    public bool isGrounded { get; private set; }

    //Must-have variables for movements
    [SerializeField] IJumpingInput jumpInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = movingObject.GetComponent<Rigidbody2D>();
        anim = spriteObject.GetComponent<Animator>();
        jumpInput = GetComponent<IJumpingInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Jumping();
    }

    protected virtual void Jumping()   // Add dependency injection
    {
        if (rb.gravityScale == 0f) return; // Do not jump while dashing
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //Input
        bool jump = jumpInput.trigger;
        bool jumpRelease = jumpInput.release;
        bool airJump = jumpInput.AirJump(isGrounded, jump);

        //Jump
        if (jump && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
            anim.SetTrigger("takeOff");
            //dustTimeOnAir = 0.1f;
            //AudioManager.instance.PlayRandomPitchSFX(1);
        }

        //Longer hold, higher jump
        if (jumpRelease && rb.velocity.y > 0)
        {
            rb.velocity = Vector2.up * jumpforce * 0.25f;
        }

        //Double Jump (jump once more before landing)
        if (airJump == true)
        {
            rb.velocity = Vector2.up * jumpforce;
            anim.SetTrigger("takeOff");
            //dustTimeOnAir = 0.1f;
            //AudioManager.instance.PlayRandomPitchSFX(1);
        }

        //Jump animation
        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
    }
}
