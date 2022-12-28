using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AbstractState
{
    AbstractState DoState(FlyEnemyBehavior flyBehavior);
}