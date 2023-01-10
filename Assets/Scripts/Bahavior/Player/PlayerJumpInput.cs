using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpInput : PlayerBehavior, IJumpingInput
{
    public bool trigger { get; private set; }
    public bool release { get; private set; }

    // Update is called once per frame
    void Update()
    {
        //TriggerJump();
    }

    public void TriggerJumpppppppp()
    {
        if (UIUsingCheck() == false)
        {
            trigger = Input.GetKeyDown(KeyCode.K);
            release = Input.GetKeyUp(KeyCode.K);
        }
        else
        {
            trigger = false;
            release = false;
        }
    }

    public void TriggerJump()
    {
        trigger = true;
        release = false;
    }

    public void ReleaseJump()
    {
        trigger = false;
        release = true;
    }

    private bool isAirJumped = false;

    public bool AirJump(bool isGrounded, bool isTrigggered)
    {
        if (isGrounded == true)
        {
            isAirJumped = false;
        }
        else if (isAirJumped == false && isTrigggered == true)
        {
            isAirJumped = true;
            return true;
        }
        return false;
    }
}
