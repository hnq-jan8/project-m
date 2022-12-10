using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJumpingInput
{
    // Input for Jump()
    bool press { get; }
    bool release { get; }
}
