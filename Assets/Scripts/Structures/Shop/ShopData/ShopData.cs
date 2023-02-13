using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Data", menuName = "Shop Data")]
public class ShopData : ScriptableObject
{
    [SerializeField] private List<Stock> stockList;

    public List<Stock> GetStockList()
    {
        return stockList;
    }

    public void RemoveStockAt(int index)
    {
        stockList.RemoveAt(index);
    }
}
