using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolderDisplayer : MonoBehaviour
{
    [SerializeField] private ItemHolder itemHolder;
    [SerializeField] private Slot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(FindObjectOfType<ItemHolderManager>() == true);
        itemHolder = FindObjectOfType<ItemHolderManager>().GetItemHolder();
        //Debug.Log(itemHolder);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplayer();
    }

    public void UpdateDisplayer()
    {
        for(int i = 0; i < itemHolder.GetItemListSize(); i++)
        {
            slots[i].SetItem(itemHolder.GetItemDataAtSlot(i));
            slots[i].DisplayItem();
        }
    }
}
