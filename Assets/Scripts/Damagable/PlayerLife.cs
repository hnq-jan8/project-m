using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLife : Life
{
    public UnityEvent OnHealing;

    [SerializeField] private HealthUI healthUI;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        healthUI = FindObjectOfType<HealthUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Heal(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            base.Heal(1);
            OnHealing.Invoke();
        }
    }

    public override void TakeDamage(int damageTaken)
    {
        if (damageTaken > GetMaxHealth()) damageTaken = GetMaxHealth();
        base.TakeDamage(damageTaken);
    }

    public override void Die()
    {
        //health = 0;

        //Subtract 50% money
        PlayerWalletManager.instance.payMoney(PlayerWalletManager.instance.getMoney() / 2);

        //Respawn at checkpoint
        CheckPointManager.instance.LoadCheckPoint();
    }
}
