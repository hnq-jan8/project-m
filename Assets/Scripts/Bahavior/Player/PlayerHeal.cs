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
        playerLife = PlayerSingleton.instance.GetComponent<Life>();
    }

    // Update is called once per frame
    void Update()
    {
        Heal();
    }

    void Heal()
    {
        if(Input.GetKeyDown(healKey))
        {
            if (ItemHolderManager.instance.GetOtherItemHolder().HasItem(herbItemData))
            {
                playerLife.Heal(1);
            }
        }
    }
}
