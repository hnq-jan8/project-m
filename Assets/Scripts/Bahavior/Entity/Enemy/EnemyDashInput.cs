using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDashInput : MonoBehaviour, IDashInput
{
    public bool trigger { get; private set; }

    public void TriggerDash()
    {
        trigger = true;
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

    void ResetDash()
    {
        isDashed = false;
        trigger = false;
    }

    public bool CanDash()
    {
        return landed && !isDashed;
    }
}
