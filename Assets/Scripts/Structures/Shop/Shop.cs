using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopUI { get; private set; }

    [SerializeField] private string shopName;
    //[SerializeField] private Stock[] stockList;
    [SerializeField] private List<Stock> stockList;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Stock GetStockAt(int index)
    {
        return stockList[index];
    }

    public void sellItem(int index)
    {
        stockList.RemoveAt(index);
    }
}
