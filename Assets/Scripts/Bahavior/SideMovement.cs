using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMovement : MonoBehaviour
{
    [Header("Animations")]
    [SerializeField] GameObject spriteObject;
    [SerializeField] private Animator anim;
    [Header("Stats")]
    [SerializeField] float speed;
    [SerializeField] bool facingRight = true;

    //Must-have variables for movements
    [SerializeField] ISideMovementInput moveInput;
    [SerializeField] GameObject movingObject;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] TrailRenderer tr;

    [Header("Dash")]
    [SerializeField] float dashPower;
    [SerializeField] float dashTime ;
    [SerializeField] float dashCoolDown;
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask whatIsGround;

    private bool isDashing;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = movingObject.GetComponent<Rigidbody2D>();
        if(spriteObject != null) anim = spriteObject.GetComponent<Animator>();
        //spriteObject = movingObject.transform.Find("PlayerSprite").gameObject;
        moveInput = GetComponent<ISideMovementInput>();
    }

    // Update is called once per frame
    void Update()
    {
        SideMove();
    }

    protected virtual void SideMove()     //Added dependency injection
    {
        if (PauseMenu.gameIsPaused == true) return;
        if (rb.gravityScale == 0f) return; // Do not move while dashing

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //Input
        float input = moveInput.input;
        bool dash = moveInput.Dash(dashCoolDown, isGrounded);

        rb.velocity = new Vector2(input * speed, rb.velocity.y);

        //Move animation
        if(anim != null)
        {
            if (input == 0)
            {
                anim.SetBool("isRunning", false);
            }
            else
            {
                anim.SetBool("isRunning", true);
            }
        }

        //Dash
        if (dash)
        {
            StartCoroutine(Dash());
        }

        if (input > 0 && facingRight == false)
        {
            Flip();
        }
        else if (input < 0 && facingRight == true)
        {
            Flip();
        }
    }

    void Flip()
    {
        movingObject.transform.localScale = new Vector3(-movingObject.transform.localScale.x, movingObject.transform.localScale.y, movingObject.transform.localScale.z);
        facingRight = !facingRight;
    }

    IEnumerator Dash()
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
