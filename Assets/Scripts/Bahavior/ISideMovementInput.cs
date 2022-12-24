using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISideMovementInput
{
    float input { get; }
    bool triggerDash { get; }
    bool Dash(float coolDown, bool isGrounded);
}
