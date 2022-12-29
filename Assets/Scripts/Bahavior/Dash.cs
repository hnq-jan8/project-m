using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MovementBehavior
{
    [Header("Animations")]
    [SerializeField] GameObject spriteObject;
    [SerializeField] private Animator anim;
    [Header("Stats")]
    [SerializeField] float dashPower;
    [SerializeField] float dashTime;
    [SerializeField] float dashCoolDown;

    //Must-have variables for movements
    [SerializeField] IDashInput dashInput;
    [SerializeField] TrailRenderer tr;

    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask whatIsGround;

    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = movingObject.GetComponent<Rigidbody2D>();
        /*anim = spriteObject.GetComponent<Animator>();*/
        dashInput = GetComponent<IDashInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Dashing();
    }

    protected virtual void Dashing()
    {
        if (PauseMenu.gameIsPaused == true) return;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //Input
        bool canDash = dashInput.CanDash(dashCoolDown, isGrounded);

        //Dash animation
        /*...*/

        //Dash
        if (canDash)
        {
            StartCoroutine(Pushing());
        }
    }

    IEnumerator Pushing()
    {
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(movingObject.transform.localScale.x * dashPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
    }
}
