using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeBehavior : MonoBehaviour, ILife
{
    public string triggerDamageTag { get; private set; }

    private void Awake()
    {
        //triggerDamageTag = "Enemy";
    }

    private void OnEnable()
    {
        triggerDamageTag = "Enemy";
    }
}
