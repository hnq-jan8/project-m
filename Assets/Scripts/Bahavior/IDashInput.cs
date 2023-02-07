using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDashInput
{
    bool trigger { get; }
    void TriggerDash();
    bool RequestDash(bool trigger, float coolDown, bool isGrounded);
    bool CanDash();
}
