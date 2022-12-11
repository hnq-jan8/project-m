using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBehavior : MonoBehaviour
{
    public bool UIUsingCheck()
    {
        return UIManager.PlayerisUsingUI;
    }
}
