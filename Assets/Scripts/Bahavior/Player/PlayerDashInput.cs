using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDashInput : PlayerBehavior, IDashInput
{
    public bool trigger { get; private set; }

    ItemHolder abilityHolder;
    [SerializeField] ItemData dashItem;

    void Start()
    {
        abilityHolder = FindObjectOfType<ItemHolderManager>().GetAbilityHolder();
    }

    // Update is called once per frame
    /*void Update()
    {
        if (UIUsingCheck() == false)
        {
            trigger = Input.GetKeyDown(KeyCode.L);
        }
        else
        {
            trigger = false;
        }
    }*/

    public void TriggerDash()
    {
        trigger = true;
    }

    bool IsDashAcquired()
    {
        if(abilityHolder.HasItem(dashItem))
        {
            return true;
        }
        return false;
    }

    private bool landed = false;
    private bool isDashed;

    public bool RequestDash(bool trigger, float coolDown, bool isGrounded)
    {
        if (isGrounded) landed = true;
        if (trigger && CanDash())
        {
            if (!isGrounded)
                landed = false;
            isDashed = true;
            Invoke("ResetDash", coolDown);
            return true;
        }
        return false;
    }
    public bool CanDash()
    {
        if (!IsDashAcquired()) return false;
        return landed && !isDashed;
    }

    void ResetDash()
    {
        isDashed = false;
        trigger = false;
    }
}