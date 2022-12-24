using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolderDisplayer : MonoBehaviour
{
    [SerializeField] private ItemHolder itemHolder;
    [SerializeField] private ItemType itemType;
    [SerializeField] private Slot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(FindObjectOfType<ItemHolderManager>() == true);
        switch (itemType)
        {
            case ItemType.Ability:
                itemHolder = FindObjectOfType<ItemHolderManager>().GetAbilityHolder();
                break;
            case ItemType.Rune:
                itemHolder = FindObjectOfType<ItemHolderManager>().GetRuneHolder();
                break;
            case ItemType.Other:
                itemHolder = FindObjectOfType<ItemHolderManager>().GetOtherItemHolder();
                break;
        }
        slots = GetComponentsInChildren<Slot>();
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
            Debug.Log(i);
            slots[i].SetItem(itemHolder.GetItemDataAtSlot(i));
            slots[i].DisplayItem();
        }
    }
}
