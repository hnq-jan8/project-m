using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityLife : MonoBehaviour, ILife
{
    public string triggerDamageTag { get; private set; }

    private void Awake()
    {
        triggerDamageTag = "Attack";
        Debug.Log(triggerDamageTag + " set");
    }
}
