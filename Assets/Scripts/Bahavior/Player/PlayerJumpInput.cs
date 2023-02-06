using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJumpInput : PlayerBehavior, IJumpingInput
{
    public bool trigger { get; private set; }
    public bool release { get; private set; }

    ItemHolder abilityHolder;
    [SerializeField] ItemData airJumpItem;

    void Start()
    {
        abilityHolder = FindObjectOfType<ItemHolderManager>().GetAbilityHolder();
    }

    // Update is called once per frame
    void Update()
    {
        //TriggerJump();
    }

    public void TriggerJumpppppppp()
    {
        if (UIUsingCheck() == false)
        {
            trigger = Input.GetKeyDown(KeyCode.K);
            release = Input.GetKeyUp(KeyCode.K);
        }
        else
        {
            trigger = false;
            release = false;
        }
    }

    bool IsDoubleJumpAcquired()
    {
        if (abilityHolder.HasItem(airJumpItem))
        {
            return true;
        }
        return false;
    }

    public void TriggerJump()
    {
        trigger = true;
        release = false;
    }

    public void ReleaseJump()
    {
        trigger = false;
        release = true;
    }

    private bool canAirJump = true;

    public bool AirJump(bool isGrounded, bool isTrigggered)
    {
        if (!IsDoubleJumpAcquired()) return false;
        if (isGrounded) ResetAirJump();
        else if (isTrigggered && canAirJump)
        {
            canAirJump = false;
            return true;
        }
        return false;
    }

    public void ResetAirJump()
    {
        canAirJump = true;
    }
}
