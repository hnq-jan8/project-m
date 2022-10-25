using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocusPoint : MonoBehaviour
{
    public Rigidbody2D rb;

    public Transform lookUpPoint;
    public Transform lookDownPoint;
    public Transform normalPoint;

    private void Start()
    {
       
    }

    void Update()
    {


        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (transform.position != normalPoint.position)
                rb.MovePosition(normalPoint.position);
            else
                return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.MovePosition(lookUpPoint.position);
        }
        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            rb.MovePosition(normalPoint.position);
        }
    }
}
