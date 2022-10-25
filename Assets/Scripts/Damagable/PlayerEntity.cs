using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{

    public override void Die()
    {
        Debug.Log("The player died!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
