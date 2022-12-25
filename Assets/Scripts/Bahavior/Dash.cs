using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
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
    [SerializeField] GameObject movingObject;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] TrailRenderer tr;

    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask whatIsGround;

    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = movingObject.GetComponent<Rigidbody2D>();
        if (spriteObject != null) anim = spriteObject.GetComponent<Animator>();
        dashInput = GetComponent<IDashInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Dashi();
    }

    protected virtual void Dashi()
    {
        if (PauseMenu.gameIsPaused == true) return;
/*        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);*/
        //update isGrounded from Jump
        isGrounded = GetComponent<Jump>().isGrounded;

        //Input
        bool dash = dashInput.Dash(dashCoolDown, isGrounded);

        //Dash animation
        /*...*/

        //Dash
        if (dash)
        {
            StartCoroutine(Dashing());
        }
    }

    IEnumerator Dashing()
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
