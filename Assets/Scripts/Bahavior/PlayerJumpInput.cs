using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpInput : PlayerBehavior, IJumpingInput
{
    public bool press { get; private set; }
    public bool release { get; private set; }

    // Update is called once per frame
    void Update()
    {
        if (UIUsingCheck() == false)
        {
            press = Input.GetKeyDown(KeyCode.K);
            release = Input.GetKeyUp(KeyCode.K);
        }
        else
        {
            press = false;
            release = false;
        }
    }
}
