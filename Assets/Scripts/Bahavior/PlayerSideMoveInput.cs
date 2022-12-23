using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideMoveInput : PlayerBehavior, ISideMovementInput
{
    public float input { get; private set; }
    public bool dashInput { get; private set; }

    // Update is called once per frame
    void Update()
    {
        if (UIUsingCheck() == false)
        {
            input = Input.GetAxisRaw("Horizontal");
            dashInput = Input.GetKeyDown(KeyCode.L);
        }
        else
        {
            input = 0f;
            dashInput = false;
        }
    }
}