using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJumpingInput
{
    bool press { get; }
    bool release { get; }
}
