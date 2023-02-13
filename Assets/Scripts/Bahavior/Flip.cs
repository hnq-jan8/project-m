using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MovementBehavior
{
    /*[SerializeField] private GameObject movingObject;*/
    [SerializeField] private bool facingRight;
    [SerializeField] private float offset;

    protected override void Start()
    {
        base.Start();
    }

    public void DoFlipByInput(float input)
    {
        if (input > 0 && facingRight == false)
        {
            Flipping();
        }
        else if (input < 0 && facingRight == true)
        {
            Flipping();
        }
        else
        {
            return;
        }
    }

    public void DoFlipByTargetPosition(Transform target)
    {
        if (transform.position.x - offset > target.position.x && facingRight == true)        //Target is to the left
        {
            Flipping();
            //Debug.Log("L");
        }
        else if (transform.position.x + offset < target.position.x && facingRight == false)
        {
            Flipping();
            //Debug.Log("R");
        }
    }

    void Flipping()
    {
        movingObject.transform.localScale = new Vector3(-movingObject.transform.localScale.x, movingObject.transform.localScale.y, movingObject.transform.localScale.z);
        facingRight = !facingRight;
    }
}
