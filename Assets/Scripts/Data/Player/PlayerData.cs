using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Physics")]
    public GameObject self;
    /*public Rigidbody2D rb;*/

    [Header("Ground Check")]
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    [Header("Animation")]
    public GameObject spriteObject;
    public Animator anim { get; private set; }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    private void Start()
    {
        anim = spriteObject.GetComponent<Animator>();
    }
}
