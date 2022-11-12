using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ScriptableObject
{
    [Header("Basic info")]
    [SerializeField] private string itemName;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;
    [SerializeField] private bool stackable;
    //The attribute 'int amount' may be declared here later

    public string GetName()
    {
        return itemName;
    }

    public string GetDesc()
    {
        return description;
    }

    public Sprite GetSprite()
    {
        return icon;
    }

    public bool IsStackable()
    {
        return stackable;
    }
}
