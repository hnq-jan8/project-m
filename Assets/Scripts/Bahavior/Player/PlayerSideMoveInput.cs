using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideMoveInput : PlayerBehavior, ISideMovementInput
{
    public float input { get; private set; }
    public bool triggerDash { get; private set; }

    public void UpdateInput()
    {
        //throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        if (UIUsingCheck() == false)
        {
            input = Input.GetAxisRaw("Horizontal");
            triggerDash = Input.GetKeyDown(KeyCode.L);
        }
        else
        {
            input = 0f;
            triggerDash = false;
        }
    }

    private bool canDash;
    private bool isDashed = false;

    public bool Dash(float coolDown, bool isGrounded)
    {
        if (isGrounded) canDash = true;
        if (triggerDash && canDash && !isDashed)
        {
            if (!isGrounded)
                canDash = false;
            isDashed = true;
            Invoke("ResetDash", coolDown);
            return true;
        }
        return false;
    }

    void ResetDash()
    {
        isDashed = false;
    }
}