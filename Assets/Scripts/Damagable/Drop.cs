using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Drop
{
    [SerializeField] private GameObject dropObject;
    [SerializeField] private int amount;

    public GameObject getDropObject()
    {
        return dropObject;
    }
    public int getAmount()
    {
        return amount;
    }
}
