using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    //Physics
    [SerializeField] protected GameObject movingObject;
    [SerializeField] protected Rigidbody2D rb;

    //Ground Check
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask whatIsGround;

    //Animation
    [SerializeField] GameObject spriteObject;
    [SerializeField] protected Animator anim;

    [SerializeField] protected bool isGrounded { get; private set; }

    protected virtual void Start()
    {
        /*isGrounded = true;*/
        if (PlayerSingleton.instance.GetComponent<PlayerData>() != null)
        {
            Debug.LogError("usth 180 tin 3 nam");
        }
        playerData = PlayerSingleton.instance.GetComponent<PlayerData>();


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
            Debug.Log(groundCheck);
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
        /*if (groundCheck == null)
        {
            Debug.Log("Ground check is null");
        }
        if (checkRadius == 0)
        {
            Debug.Log("Check radius is 0");
        }
        if (whatIsGround == 0)
        {
            Debug.Log("whatIsGround is null");
        }*/

        /*isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);*/
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
