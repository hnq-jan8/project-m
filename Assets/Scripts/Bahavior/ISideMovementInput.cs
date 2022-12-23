using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISideMovementInput
{
    float input { get; }
    bool dashInput { get; }
}
