using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeal : MonoBehaviour
{
    [SerializeField] private KeyCode healKey;
    [SerializeField] private ItemData herbItemData;
    [SerializeField] private ParticleSystem healParticle;
    [SerializeField] private ParticleSystem healEnergy;

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

        healParticle.Stop();
        healParticle.Play();
        healEnergy.Stop();
        healEnergy.Play();
    }

    public void FullHeal()
    {
        //playerLife.Heal(playerLife.GetMaxHealth() - playerLife.GetHealth());
        for(int i = 0; i < playerLife.GetMaxHealth(); i++)
        {
            playerLife.Heal(1);
        }
        Debug.Log("FullHeal");
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
