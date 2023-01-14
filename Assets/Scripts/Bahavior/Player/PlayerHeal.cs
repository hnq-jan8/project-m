using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeal : MonoBehaviour
{
    [SerializeField] private KeyCode healKey;
    [SerializeField] private ItemData herbItemData;

    private Life playerLife;


    // Start is called before the first frame update
    void Start()
    {
        playerLife = PlayerSingleton.instance.GetComponent<PlayerLife>();
    }

    // Update is called once per frame
    void Update()
    {
        HealCheck();
    }

    void Heal()
    {
        playerLife.Heal(1);
    }

    public void FullHeal()
    {
        playerLife.Heal(playerLife.GetMaxHealth() - playerLife.GetHealth());
    }

    void HealCheck()
    {
        if (Input.GetKeyDown(healKey))
        {
            if (ItemHolderManager.instance.GetOtherItemHolder().HasItem(herbItemData) && playerLife.GetHealth() < playerLife.GetMaxHealth())
            {
                Heal();
                ItemHolderManager.instance.GetOtherItemHolder().RemoveItem(herbItemData, 1);
            }
        }
    }
}
