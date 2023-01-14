using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Shop shop;
    [SerializeField] private Transform stockContent;
    [SerializeField] private Transform stock;
    [SerializeField] private List<Slot> stockUIList;

    [SerializeField] private TextMeshProUGUI shopName, itemName, description;

    public UnityEvent OnSellItem;

    // Start is called before the first frame update
    void Start()
    {
        shopName.text = shop.GetShopName();
        for (int i = 0; i < shop.GetStockList().Count; i++)
        {
            GameObject newStock = Instantiate(stock, stockContent).gameObject;
            Slot temp = newStock.GetComponent<Slot>();
            temp.SetItem(shop.GetStockAt(i).GetItemData());
            temp.SetText(shop.GetStockAt(i).GetPrice().ToString());
            if (PlayerWalletManager.instance != null && shop.GetStockAt(i).GetPrice() > PlayerWalletManager.instance.getMoney())
            {
                //Debug.Log("a");
                Color c = new Color(1, 1, 1, 0.55f);
                temp.SetTextColor(c);
                temp.SetIconColor(c);
            }
            temp.DisplayItem();
            stockUIList.Add(temp);
        }
        EventSystem.current.firstSelectedGameObject = stockUIList[0].gameObject;
        stock.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Debug.Log("Shop UI enabled");
        UpdateStock();
    }

    public void UpdateUI()
    {
        //stockList = shop.GetStockList();
        GameObject currentSelected = EventSystem.current.currentSelectedGameObject;
        ItemData currentSelectedItem = currentSelected.GetComponent<Slot>().GetItem();
        UpdateItemName(currentSelectedItem.GetName());
        UpdateDescription(currentSelectedItem.GetDesc());
    }

    public void UpdateStock()
    {
        for (int i = 0; i < stockUIList.Count; i++)
        {
            Slot temp = stockUIList[i];
            if (PlayerWalletManager.instance != null && shop.GetStockAt(i).GetPrice() > PlayerWalletManager.instance.getMoney())
            {
                Color c = new Color(1, 1, 1, 0.55f);
                temp.SetTextColor(c);
                temp.SetIconColor(c);
            }
        }
    }

    public void UpdateItemName(string name)
    {
        this.itemName.text = name;
    }

    public void UpdateDescription(string desc)
    {
        this.description.text = desc;
    }

    public int GetCurrentSelectedItemIndex()
    {
        GameObject currentSelected = EventSystem.current.currentSelectedGameObject;
        foreach(Slot temp in stockUIList)
        {
            if(temp == currentSelected.GetComponent<Slot>())
            {
                return stockUIList.IndexOf(temp);
            }
        }
        return -1;
    }

    public void SellItem()
    {
        bool canSell = shop.SellItem(GetCurrentSelectedItemIndex());
        if (EventSystem.current.currentSelectedGameObject.GetComponent<Slot>().GetItem().IsStackable() == false && canSell == true)
        {
            stockUIList.RemoveAt(GetCurrentSelectedItemIndex());
            Destroy(EventSystem.current.currentSelectedGameObject);
            EventSystem.current.SetSelectedGameObject(stockUIList[0].gameObject);

            UpdateStock();

            OnSellItem.Invoke();
            //Debug.Log(EventSystem.current.currentSelectedGameObject.GetComponent<Slot>().GetItem().GetName());
            //EventSystem.current.firstSelectedGameObject
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
