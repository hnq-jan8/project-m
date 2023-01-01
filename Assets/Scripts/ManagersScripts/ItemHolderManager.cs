using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolderManager : MonoBehaviour
{
    //Register every item holders!
    [SerializeField] private ItemHolder itemHolder;
    [SerializeField] private ItemHolder abilityHolder, runeHolder, otherItemHolder;

    [SerializeField] private bool resetOnDisable;

    private void Update()
    {
         
    }
    private void OnEnable()
    {
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
}
