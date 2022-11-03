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
        //float input = Input.GetAxisRaw("Horizontal");
        float input = moveInput.input;
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
}
