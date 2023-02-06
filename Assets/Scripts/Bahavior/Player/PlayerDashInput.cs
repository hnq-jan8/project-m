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
    void Update()
    {
        /*if (UIUsingCheck() == false)
        {
            trigger = Input.GetKeyDown(KeyCode.L);
        }
        else
        {
            trigger = false;
        }*/
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

    public void SetTrigger(bool trig)
    {
        trigger = trig;
    }

    public bool RequestDash(float coolDown, bool isGrounded)
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
        //Debug.LogError("A");
        if (!IsDashAcquired()) return false;
        if(landed == false)
        {
            if(isDashed == true)
            {
                return false;
            }
        }
        return true;
    }

    void ResetDash()
    {
        isDashed = false;
    }
}