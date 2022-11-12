using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ability holder", menuName = "Item Holder/Ability Holder")]
public class AbilityHolder : ItemHolder
{
    public override ItemHolder getType()
    {
        //Debug.Log("Hello");
        return this;
    }
}
