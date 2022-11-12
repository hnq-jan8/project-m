using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilityItem : Item
{
    private void Start()
    {
        holder = FindObjectOfType<AbilityHolderManager>().GetItemHolder();
        //Debug.Log(holder);
    }
}
