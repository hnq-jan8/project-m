using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDashInput
{
    bool trigger { get; }
    bool Dash(float coolDown, bool isGrounded);
}

