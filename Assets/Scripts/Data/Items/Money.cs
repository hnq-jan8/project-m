using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : Life
{
    public override void Die()
    {
        AddToWallet();
        Destroy(this.gameObject);
    }

    void AddToWallet()
    {
        PlayerWalletManager.instance.gainMoney();
    }
}
