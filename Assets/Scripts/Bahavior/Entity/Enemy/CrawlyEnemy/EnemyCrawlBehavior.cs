using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrawlBehavior : MonoBehaviour
{

    //[SerializeField] float moveSpeed = 1f;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] Transform wallCheck;
    [SerializeField] LayerMask groundLayer;

    public CrawlAbstractState currentState;

    //States
    public CrawlyIdleState idleState = new CrawlyIdleState();
    public CrawlState crawlState = new CrawlState();

    //Animation
    public Animator anim { get; private set; }

    //RigidBody
    public Rigidbody2D rb { get; private set; }

    //Flip behavior
    public Flip flip { get; private set; }

    //Sidemove
    public SideMove sideMove { get; private set; }

    private float checkRadius = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        currentState = idleState;

        //RigidBody
        rb = GetComponent<Rigidbody2D>();

        //Flip behavior
        flip = GetComponentInChildren<Flip>();

        //Side move input
        sideMove = GetComponentInChildren<SideMove>();

        anim = GetComponentInChildren<Animator>();
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckCollider.position, checkRadius, groundLayer);
    }

    public bool IsFacingWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, checkRadius, groundLayer);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.DoState(this);
    }

}



