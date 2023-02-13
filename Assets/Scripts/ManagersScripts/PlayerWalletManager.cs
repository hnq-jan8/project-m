using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalletManager : MonoBehaviour, ISaveable
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

    public object CaptureState()
    {
        return new SaveData
        {
            saveMoney = money
        };
    }

    public void RestoreState(object state)
    {
        var saveData = (SaveData)state;
        money = saveData.saveMoney;
        Debug.LogError("Restoring data for: " + this.gameObject.name);
    }

    [System.Serializable]
    private struct SaveData
    {
        public int saveMoney;
    }
}
