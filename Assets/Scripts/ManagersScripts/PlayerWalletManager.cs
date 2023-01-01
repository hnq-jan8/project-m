using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalletManager : MonoBehaviour
{
    public static PlayerWalletManager instance;

    [SerializeField] private int money;


    private void Start()
    {
        instance = this;
    }

    public int getMoney()
    {
        return money;
    }

    public void payMoney(int amount)
    {
        money -= amount;
    }

    public void gainMoney()
    {
        money++;
    }
}
