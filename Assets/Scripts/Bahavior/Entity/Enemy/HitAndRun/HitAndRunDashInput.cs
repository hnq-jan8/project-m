using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAndRunDashInput : MonoBehaviour, IDashInput
{
    public bool trigger { get; private set; }

    public bool CanDash(float coolDown, bool isGrounded)
    {
        if (trigger)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
