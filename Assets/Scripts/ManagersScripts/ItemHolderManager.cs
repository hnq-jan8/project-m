using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolderManager : MonoBehaviour
{
    //Register every item holders!
    [SerializeField] private ItemHolder itemHolder;
    [SerializeField] private ItemHolder abilityHolder;

    private void Update()
    {
         
    }

    public ItemHolder GetAbilityHolder()
    {
        return abilityHolder;
    }
}
