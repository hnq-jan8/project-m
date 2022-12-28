using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stock
{
    [SerializeField] private ItemData itemdata;
    [SerializeField] private int price;

    public ItemData GetItemData()
    {
        return itemdata;
    }

    public int GetPrice()
    {
        return price;
    }
}
