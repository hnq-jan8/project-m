using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MovementBehavior
{
    [Header("Stats")]
    [SerializeField] float jumpforce;

    //Must-have variables for movements
    public IJumpingInput jumpInput { get; private set; }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        jumpInput = GetComponent<IJumpingInput>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        //Jumping();
    }

    public virtual void Jumping()   // Add dependency injection
    {
        if (rb.gravityScale == 0f) return; // Do not jump while dashing

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
