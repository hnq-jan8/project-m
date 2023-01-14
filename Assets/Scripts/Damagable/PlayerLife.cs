using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLife : Life
{
    public UnityEvent OnHealing;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Heal(int amount)
    {
        base.Heal(amount);
        OnHealing.Invoke();
    }

    public override void Die()
    {
        //Subtract 50% money
        PlayerWalletManager.instance.payMoney(PlayerWalletManager.instance.getMoney() / 2);

        //Respawn at checkpoint
        CheckPointManager.instance.LoadCheckPoint();
    }
}
