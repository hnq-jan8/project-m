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

    private bool canAirJump = true;

    public bool AirJump(bool isGrounded, bool isTrigggered)
    {
        /*Debug.Log(canAirJump);*/
        if (isGrounded) ResetAirJump();
        else if (isTrigggered && canAirJump)
        {
            canAirJump = false;
            return true;
        }
        return false;
    }

    public void ResetAirJump()
    {
        canAirJump = true;
    }
}
