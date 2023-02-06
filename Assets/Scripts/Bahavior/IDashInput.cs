using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDashInput
{
    bool trigger { get; }
    void SetTrigger(bool trig);
    bool RequestDash(float coolDown, bool isGrounded);
    bool CanDash();
}
