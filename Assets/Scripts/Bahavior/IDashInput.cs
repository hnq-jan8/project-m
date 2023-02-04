using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDashInput
{
    bool trigger { get; }
    bool RequestDash(float coolDown, bool isGrounded);
    bool CanDash();
}
