using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    private MovementData movementData;

    //Physics
    protected GameObject movingObject;
    protected Rigidbody2D rb;

    //Ground Check
    Transform groundCheck;
    float checkRadius;
    LayerMask whatIsGround;

    //Animation
    GameObject spriteObject;
    protected Animator anim;

    protected bool isGrounded { get; private set; }

    protected virtual void Start()
    {
        //playerData = FindObjectOfType<MovementData>();
        movementData = GetComponentInParent<MovementData>();

        //movingObject & rb
        if (movementData.self == null)
        {
            Debug.LogError("Please insert a moving object for the PlayerData of: " + this.gameObject.name);
        }
        else
        {
            movingObject = movementData.self;
            rb = movingObject.GetComponent<Rigidbody2D>();
        }

        //groundCheck
        if (movementData.groundCheck == null)
        {
            Debug.LogError("Please insert a ground check for the PlayerData of: " + this.gameObject.name);
        }
        else
        {
            groundCheck = movementData.groundCheck;
        }

        //checkRadius
        if (movementData.checkRadius == 0)
        {
            Debug.LogError("Please insert a check radius higher than 0 for the PlayerData of: " + this.gameObject.name);
        }
        else
        {
            checkRadius = movementData.checkRadius;
        }

        //whatIsGround
        if (movementData.whatIsGround == 0)
        {
            Debug.LogError("Please insert a Ground layer for the PlayerData of: " + this.gameObject.name);
        }
        else
        {
            whatIsGround = movementData.whatIsGround;
        }

        //Animation
        if (movementData.spriteObject == null)
        {
            Debug.LogError("Please insert a game object with ANIMATOR for the PlayerData of: " + this.gameObject.name);
        }
        else
        {
            spriteObject = movementData.spriteObject;
            anim = spriteObject.GetComponent<Animator>();
        }

    }

    protected virtual void Update()
    {
        if(groundCheck != null) 
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
