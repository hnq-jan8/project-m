using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    [SerializeField] protected ItemHolder holder;
    [SerializeField] private SpriteRenderer itemIcon;

    // Start is called before the first frame update
    void Start()
    {
        holder = FindObjectOfType<AbilityHolderManager>().GetItemHolder();

        /*if (GetComponent<ItemData>() == null)
        {
            Debug.LogError("An item must have an item data!");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        itemIcon.sprite = itemData.GetSprite();
    }

    public ItemData GetItemData()
    {
        return itemData;
    }

    //Do stuffs if obtained (touched) by player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ObtainItem();
        }
    }

    public void ObtainItem()
    {
        holder.AddItem(this.itemData);
        Destroy(gameObject);
    }
}
