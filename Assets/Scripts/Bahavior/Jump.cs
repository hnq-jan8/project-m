using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : PlayerBehavior
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
    public bool isAirJumped { get; private set; }

    //Must-have variables for movements
    [SerializeField] GameObject movingObject;
    [SerializeField] Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = movingObject.GetComponent<Rigidbody2D>();
        anim = spriteObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(UIUsingCheck() == false)
        {
            Jumping();
        }
    }

    public void Jumping()      //Adding dependency injection later
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //Jump
        if (Input.GetKeyDown(KeyCode.K) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
            anim.SetTrigger("takeOff");
            //dustTimeOnAir = 0.1f;
            //AudioManager.instance.PlayRandomPitchSFX(1);
        }

        //Longer hold, higher jump
        if (Input.GetKeyUp(KeyCode.K) && rb.velocity.y > 0)
        {
            rb.velocity = Vector2.up * jumpforce * 0.25f;
        }

        //Double Jump (jump one more on air)
        if (Input.GetKeyDown(KeyCode.K) && isGrounded == false && isAirJumped == false)
        {
            rb.velocity = Vector2.up * jumpforce;
            anim.SetTrigger("takeOff");
            isAirJumped = true;
            //dustTimeOnAir = 0.1f;
            //AudioManager.instance.PlayRandomPitchSFX(1);
        }

        //Jump animation
        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
            isAirJumped = false;
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
    }
}
