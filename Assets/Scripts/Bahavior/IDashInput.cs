using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDashInput
{
    bool trigger { get; }
    bool CanDash(float coolDown, bool isGrounded);
}
