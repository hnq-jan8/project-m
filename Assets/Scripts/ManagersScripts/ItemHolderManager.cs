using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolderManager : MonoBehaviour
{
    [SerializeField] private ItemHolder itemHolder;
    [SerializeField] private bool allowReset = false;

    private void Update()
    {
        if(allowReset == true)
        {
            itemHolder.ResetHolder();
        }
        //Debug.Log(itemHolder.GetItemListSize());
        //Debug.Log(itemHolder.GetItemAtSlot(0));   
    }

    public ItemHolder GetItemHolder()
    {
        return itemHolder.getType();
    }
}
