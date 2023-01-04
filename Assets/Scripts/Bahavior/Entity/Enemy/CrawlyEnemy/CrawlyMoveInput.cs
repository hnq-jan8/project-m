using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlyMoveInput : MonoBehaviour, ISideMovementInput
{
    public float input { get; private set; }


    public void UpdateInput()
    {
        input = -input;
        Debug.Log(input);
    }


    void Start()
    {
        input = -1;
    }


    void Update()
    {
        //Move
    }
}
