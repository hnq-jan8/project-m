using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityLifeBehavior : MonoBehaviour, ILife
{
    public string triggerDamageTag { get; private set; }

    private void Awake()
    {
        //triggerDamageTag = "Attack";
    }

    private void OnEnable()
    {
        triggerDamageTag = "Attack";
    }
}
