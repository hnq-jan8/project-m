using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideMoveInput : PlayerBehavior, ISideMovementInput
{
    public float input { get; private set; }

    public void UpdateInput()
    {
        if (UIUsingCheck() == false)
        {
            input = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            input = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (UIUsingCheck() == false)
        {
            input = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            input = 0f;
        }*/
    }
}