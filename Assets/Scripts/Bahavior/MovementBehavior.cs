using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    private PlayerData playerData;

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
        playerData = FindObjectOfType<PlayerData>();

        //movingObject & rb
        if (playerData.self == null)
        {
            Debug.LogError("Please insert a moving object for the PlayerData of: " + this.gameObject.name);
        }
        else
        {
            movingObject = playerData.self;
            rb = movingObject.GetComponent<Rigidbody2D>();
        }

        //groundCheck
        if (playerData.groundCheck == null)
        {
            Debug.LogError("Please insert a ground check for the PlayerData of: " + this.gameObject.name);
        }
        else
        {
            groundCheck = playerData.groundCheck;
        }

        //checkRadius
        if (playerData.checkRadius == 0)
        {
            Debug.LogError("Please insert a check radius higher than 0 for the PlayerData of: " + this.gameObject.name);
        }
        else
        {
            checkRadius = playerData.checkRadius;
        }

        //whatIsGround
        if (playerData.whatIsGround == 0)
        {
            Debug.LogError("Please insert a Ground layer for the PlayerData of: " + this.gameObject.name);
        }
        else
        {
            whatIsGround = playerData.whatIsGround;
        }

        //Animation
        if (playerData.spriteObject == null)
        {
            Debug.LogError("Please insert a game object with ANIMATOR for the PlayerData of: " + this.gameObject.name);
        }
        else
        {
            spriteObject = playerData.spriteObject;
            anim = spriteObject.GetComponent<Animator>();
        }

    }

    protected virtual void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
