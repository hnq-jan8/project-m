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
        TriggerJump();
    }

    void TriggerJump()
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

    public bool canAirJump(bool isGrounded, bool isTriggered)
    {
        //bool canAirJumpLocal = false;
        bool isAirJumped = false;

        if (isGrounded)
        {
            isAirJumped = false;
            return false;
        }

        if (isTriggered && isGrounded == false && isAirJumped == false)
        {
            /*canAirJumpLocal = true;*/
            isAirJumped = true;
            /*return true;*/
            /*Debug.Log("isAirJumped: " + isAirJumped);*/
        }

        if (isTriggered && isAirJumped == false && isGrounded == false) return true;
        return false;

        /*Debug.Log("canAirJumpLocal: " + canAirJumpLocal);*/
    }
}
