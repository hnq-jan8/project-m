using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    [SerializeField] protected ItemHolder itemHolder;
    [SerializeField] private SpriteRenderer itemSprite;
    [SerializeField] private ItemHolderDisplayer displayer;
    private ItemType itemType;

    // Start is called before the first frame update
    void Start()
    {
        //holder = FindObjectOfType<AbilityHolderManager>().GetItemHolder();
        itemSprite = GetComponentInChildren<SpriteRenderer>();
        itemType = itemData.GetItemType();

        if (itemData == null)
        {
            Debug.LogError("Item data is missing in item: " + this.gameObject.name);
        }
        else
        {
            itemSprite.sprite = itemData.GetSprite();
        }

        switch(itemType)
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
    }

    // Update is called once per frame
    void Update()
    {
        //If the item is not stackable and it's already been obtained (it exists in the holder), it can no longer exist in the world
        if (itemData != null && itemData.IsStackable() == false && itemHolder.HasItem(itemData))
        {
            Destroy(this.gameObject);
        }
    }

    public ItemData GetItemData()
    {
        return itemData;
    }

    //Do stuffs if obtained (touched) by player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && itemData != null)
        {
            ObtainItem();

        }
    }

    public void ObtainItem()
    {
        itemHolder.AddItem(this.itemData);
        Destroy(gameObject);
    }
}
