using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashInput : PlayerBehavior, IDashInput
{
    public bool trigger { get; private set; }

    // Update is called once per frame
    void Update()
    {
        if (UIUsingCheck() == false)
        {
            trigger = Input.GetKeyDown(KeyCode.L);
        }
        else
        {
            trigger = false;
        }
    }

    private bool canDash;
    private bool isDashed = false;

    public bool Dash(float coolDown, bool isGrounded)
    {
        if (isGrounded) canDash = true;
        if (trigger && canDash && !isDashed)
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