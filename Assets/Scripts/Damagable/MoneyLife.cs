using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyLife : MonoBehaviour, ILife
{
    public string triggerDamageTag { get; private set; }

    private void Awake()
    {
        triggerDamageTag = "Player";
    }
}
