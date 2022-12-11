using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJumpingInput
{
    bool trigger { get; }
    bool release { get; }
    bool AirJump(bool isGrounded, bool isTriggered);
}
