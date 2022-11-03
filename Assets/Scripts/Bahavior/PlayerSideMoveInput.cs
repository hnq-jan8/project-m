using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideMoveInput : MonoBehaviour, ISideMovementInput
{
    public float input { get; private set; }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
    }
}
