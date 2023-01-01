using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stock
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private int price;

    private void Start()
    {

    }

    public void SetItemData(ItemData itemData)
    {
        this.itemData = itemData;
    }

    public void SetPrice(int price)
    {
        this.price = price;
    }

    public ItemData GetItemData()
    {
        return itemData;
    }

    public int GetPrice()
    {
        return price;
    }
}
