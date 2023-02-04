using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemHolderManager : MonoBehaviour, ISaveable
{
    public static ItemHolderManager instance;

    //Register every item holders!
    [SerializeField] private ItemHolder itemHolder;
    [SerializeField] private ItemHolder abilityHolder, runeHolder, otherItemHolder;

    [SerializeField] private bool resetOnDisable;

    private void Update()
    {
        //Dictionary<ItemData, int> test = otherItemHolder.GetItemList();
        //Debug.LogError(otherItemHolder.GetItemList().Count);
    }
    private void OnEnable()
    {
        instance = this;
        if (resetOnDisable == true)
        {
            abilityHolder.ResetHolder();
            runeHolder.ResetHolder();
            otherItemHolder.ResetHolder();
        }
    }

    //For testing purposes
    private void OnDisable()
    {
        
    }

    public ItemHolder GetAbilityHolder()
    {
        return abilityHolder;
    }

    public ItemHolder GetRuneHolder()
    {
        return runeHolder;
    }

    public ItemHolder GetOtherItemHolder()
    {
        return otherItemHolder;
    }

    public object CaptureState()
    {
        return new SaveData
        {
            abilityHolderJson = JsonUtility.ToJson(abilityHolder),
            runeHolderJson = JsonUtility.ToJson(runeHolder),
            otherItemHolderJson = JsonUtility.ToJson(otherItemHolder)
        };
    }

    public void RestoreState(object state)
    {
        var saveData = (SaveData)state;

        JsonUtility.FromJsonOverwrite(saveData.abilityHolderJson, abilityHolder);
        JsonUtility.FromJsonOverwrite(saveData.runeHolderJson, runeHolder);
        JsonUtility.FromJsonOverwrite(saveData.otherItemHolderJson, otherItemHolder);
    }

    [Serializable]
    private struct SaveData
    {
        /*public ItemHolder abilitHolder;
        public ItemHolder runeHolder;
        public ItemHolder otherItemHolder;*/

        public string abilityHolderJson;
        public string runeHolderJson;
        public string otherItemHolderJson;
    }
}
