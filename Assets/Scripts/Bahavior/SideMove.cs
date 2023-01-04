using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMove : MovementBehavior
{
    [Header("Stats")]
    [SerializeField] float speed;
    [SerializeField] bool facingRight = true;

    //Must-have variables for movements
    public ISideMovementInput moveInput { get; private set; }
    public float input { get; private set; }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        moveInput = GetComponent<ISideMovementInput>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        //Debug.LogError(input);
    }

    public void Move()     //Added dependency injection
    {
        //if (PauseMenu.gameIsPaused == true) return;
        //float input = Input.GetAxisRaw("Horizontal");
        input = moveInput.input;
        //Debug.Log("Moving");
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }

    public void StopMove()
    {
        input = 0;
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
        //Debug.Log("Stopped Moving");
    }

    public void DoFlip()
    {
        input = moveInput.input;
        if (input > 0 && facingRight == false)
        {
            Flip();
        }
        else if (input < 0 && facingRight == true)
        {
            Flip();
        }
    }

    public void Flip()
    {
        movingObject.transform.localScale = new Vector3(-movingObject.transform.localScale.x, movingObject.transform.localScale.y, movingObject.transform.localScale.z);
        facingRight = !facingRight;
    }
}
