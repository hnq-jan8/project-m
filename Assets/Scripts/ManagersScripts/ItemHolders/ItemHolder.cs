using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Holder", menuName = "Item Holder")]
public class ItemHolder : ScriptableObject
{
    //[SerializeField] private Slot[] slots;
    [SerializeField] List<ItemData> itemDataList = new List<ItemData>();
    private Dictionary<ItemData, int> itemList = new Dictionary<ItemData, int>();
    [SerializeField] private int occupiedSlot = -1;     //-1 means there's no occupied slots


    public bool HasItem(ItemData itemData)
    {
        /*if(itemDataList.Contains(itemData))
        {
            return true;
        }*/

        if(itemList.ContainsKey(itemData))
        {
            return true;
        }

        return false;
    }

    //Not fixed
    public ItemData GetItemDataAtSlot(int slotIndex)
    {
        return itemDataList[slotIndex];
    }

    public void AddItem(ItemData itemData)
    {
        /*occupiedSlot++;
        if(itemList.ContainsKey(itemData))
        {
            itemList[itemData] += 1;
        }
        else
        {
            itemList[itemData] = 1;
        }*/
        AddBunchOfItem(itemData, 1);
    }

    public void AddBunchOfItem(ItemData itemData, int amount)
    {
        occupiedSlot++;
        if (itemList.ContainsKey(itemData))
        {
            itemList[itemData] += amount;
        }
        else
        {
            itemList[itemData] = amount;
        }
    }

    public void RemoveItemCompletely(ItemData itemData)
    {
        itemList.Remove(itemData);
    }

    public void RemoveItem(ItemData itemData, int amount)
    {
        if (itemList.ContainsKey(itemData))
        {
            itemList[itemData] -= amount;
        }
        else
        {
            return;
        }
    }

    public void SetItem(ItemData itemData, int amount)
    {
        //itemDataList[slotIndex] = itemData;
        itemList[itemData] = amount;
    }

    public Dictionary<ItemData, int> GetItemList()
    {
        return itemList;
    }

    public int GetItemListSize()
    {
        //return itemDataList.Count;
        return itemList.Count;
    }

    //public void Remove

    public void ResetHolder()
    {
        //itemList = new Item[];  //Reseting the itemList should use for loop and set all values of the list to null
        //itemDataList = new List<ItemData>();
        itemList = new Dictionary<ItemData, int>();
        occupiedSlot = -1;
    }

    public void LoadHolder()
    {
        
    }
}
