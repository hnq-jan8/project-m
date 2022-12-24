using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private bool isFull = false;
    [SerializeField] private bool isSelected = false;
    [SerializeField] private ItemData itemData;
    [SerializeField] private Image itemIcon;

    private void Start()
    {
        //childs
        Image[] children = GetComponentsInChildren<Image>();
        foreach (Image child in children)
        {
            if (child.gameObject.GetComponent<Slot>() == null)
            {
                itemIcon = child;
            }
        }

        //itemIcon = GetComponentInChildren<Image>();
    }

    private void Update()
    {
        //DisplayItem();
    }

    public bool IsFull()
    {
        return isFull;
    }

    public ItemData GetItem()
    {
        return itemData;
    }

    public void SetItem(ItemData itemData)
    {
        this.itemData = itemData;
        isFull = true;
    }

    public void DisplayItem()
    {
        if(itemIcon == null)
        {
            Debug.Log("You did not reference the Item Renderer for a slot!");
            return;
        }
        itemIcon.sprite = itemData.GetSprite();
        itemIcon.color = new Color(255, 255, 255, 255);
    }

    public bool IsSelected()
    {
        return isSelected;
    }
}
