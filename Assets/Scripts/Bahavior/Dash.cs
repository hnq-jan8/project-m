using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MovementBehavior
{
    [Header("Stats")]
    [SerializeField] float dashPower;
    [SerializeField] float dashTime;
    [SerializeField] float dashCoolDown;

    //Must-have variables for movements
    [SerializeField] IDashInput dashInput;
    [SerializeField] TrailRenderer tr;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        dashInput = GetComponent<IDashInput>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Dashing();
    }

    protected virtual void Dashing()
    {
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
