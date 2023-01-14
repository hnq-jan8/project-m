using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public UIOpenner shopUI { get; private set; }

    [SerializeField] private string shopName;
    //[SerializeField] private Stock[] stockList;
    [SerializeField] private List<Stock> stockList;


    // Start is called before the first frame update
    void Start()
    {
        if (GetComponentInChildren<UIOpenner>() != null) shopUI = GetComponentInChildren<UIOpenner>();
        shopUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            shopUI.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shopUI.enabled = false;
        }
    }

    public string GetShopName()
    {
        return shopName;
    }

    public List<Stock> GetStockList()
    {
        return stockList;
    }

    public Stock GetStockAt(int index)
    {
        return stockList[index];
    }

    public bool SellItem(int index)
    {
        //Check the money in the wallet
        if(PlayerWalletManager.instance.getMoney() < stockList[index].GetPrice())       //Not enough money
        {
            Debug.LogError("Not enough money!");
            return false;
        }
        else                                                                            //Enough money
        {
            //Get the sold item's itemType and then add the item to the corresponding ItemHolder
            ItemData itemData = stockList[index].GetItemData();
            //Debug.Log(itemData);
            switch (itemData.GetItemType())
            {
                case ItemType.Ability:
                    FindObjectOfType<ItemHolderManager>().GetAbilityHolder().AddItem(itemData);
                    break;
                case ItemType.Rune:
                    FindObjectOfType<ItemHolderManager>().GetRuneHolder().AddItem(itemData);
                    break;
                case ItemType.Other:
                    FindObjectOfType<ItemHolderManager>().GetOtherItemHolder().AddBunchOfItem(itemData, stockList[index].GetStockAmount());
                    break;
            }
            Debug.Log(stockList[index] == null);
            PlayerWalletManager.instance.payMoney(stockList[index].GetPrice());

            if(itemData.IsStackable() == false) stockList.RemoveAt(index);

            return true;
        }
    }
}
