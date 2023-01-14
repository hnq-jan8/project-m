using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stock
{
    [SerializeField] private ItemData itemData;
    [SerializeField][Range(1, 5)] private int stockAmount;
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

    public int GetStockAmount()
    {
        return stockAmount;
    }

    public int GetPrice()
    {
        return price;
    }
}
