using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerBaseState
{
    PlayerBaseState DoState(PlayerStateMachine playerBehavior);
}
