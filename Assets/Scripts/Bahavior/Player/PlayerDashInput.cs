using System.Collections;
using System.Collections.Generic;
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
    void Update()
    {
        if (UIUsingCheck() == false && IsDashAcquired() == true)
        {
            trigger = Input.GetKeyDown(KeyCode.L);
        }
        else
        {
            trigger = false;
        }
    }

    bool IsDashAcquired()
    {
        if(abilityHolder.HasItem(dashItem))
        {
            return true;
        }
        return false;
    }

    private bool canDash = false;
    private bool isDashed = false;

    public bool CanDash(float coolDown, bool isGrounded)
    {
        if (isGrounded) canDash = true;
        if (trigger && canDash && !isDashed)
        {
            if (!isGrounded)
                canDash = false;
            isDashed = true;
            Invoke("ResetDash", coolDown);
            return true;
        }
        return false;
    }

    void ResetDash()
    {
        isDashed = false;
    }
}