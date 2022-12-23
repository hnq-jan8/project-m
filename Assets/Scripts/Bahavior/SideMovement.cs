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
    bool facingRight = true;

    //Must-have variables for movements
    [SerializeField] ISideMovementInput moveInput;
    [SerializeField] GameObject movingObject;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] TrailRenderer tr;

    [Header("Dash")]
    private bool canDash = true;
    private bool isDashing;
    [SerializeField] float dashPower = 24f;
    [SerializeField] float dashTime = 0.2f;
    [SerializeField] float dashCoolDown = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = movingObject.GetComponent<Rigidbody2D>();
        //spriteObject = movingObject.transform.Find("PlayerSprite").gameObject;
        anim = spriteObject.GetComponent<Animator>();
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
        if (isDashing) return;

        //Input
        float input = moveInput.input;
        bool dashTrigger = moveInput.dashInput;

        rb.velocity = new Vector2(input * speed, rb.velocity.y);

        //Move animation
        if (input == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        //Dash
        if (dashTrigger && canDash)
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
        canDash = false; isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(movingObject.transform.localScale.x * dashPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }
}
