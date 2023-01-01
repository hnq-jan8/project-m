using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [Header("Physics")]
    [SerializeField] protected GameObject movingObject;
    [SerializeField] protected Rigidbody2D rb;

    [Header("Ground Check")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask whatIsGround;

    protected Animator anim;

    protected bool isGrounded { get; private set; }

    protected virtual void Start()
    {
        if(movingObject == null)
        {
            Debug.LogError("Please insert a moving object for the game object: " + this.gameObject.name);
        }
        rb = movingObject.GetComponent<Rigidbody2D>();

        if (GetComponentInChildren<Animator>() != null)
        {
            anim = GetComponentInChildren<Animator>();
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
