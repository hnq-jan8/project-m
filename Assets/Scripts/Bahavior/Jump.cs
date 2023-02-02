using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jump : MovementBehavior
{
    [Header("Stats")]
    [SerializeField] float jumpforce;

    //Must-have variables for movements
    public IJumpingInput jumpInput { get; private set; }
    public bool airJump { get; private set; }

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
        airJump = jumpInput.AirJump(isGrounded, jump);

        //Jump
        if (jump && isGrounded == true)
        {
            MoveUp(1f);
        }

        //Longer hold, higher jump
        if (jumpRelease && rb.velocity.y > 0)
        {
            MoveUp(.25f);
        }

        //Double Jump (jump once more before landing)
        if (airJump == true)
        {
            MoveUp(1f);
        }
    }

    void MoveUp(float percentage)
    {
        rb.velocity = Vector2.up * jumpforce * percentage;
    }

    public void ResetAirJump()
    {
        jumpInput.ResetAirJump();
    }
}
