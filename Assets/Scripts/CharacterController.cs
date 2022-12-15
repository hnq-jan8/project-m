using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    GameObject playerSpriteObject;

    float input;
    public float speed;
    Rigidbody2D rb;
    bool facingRight = true;

    bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;

    [Header("Player splash attack")]
    [SerializeField] private GameObject attackSlash;
    [SerializeField] private Animator slashAnim;
    [SerializeField] private bool attackIsCoolDown = true;
    [SerializeField] private float attackCoolDownTime = 0.5f;
    public CinemachineImpulseSource camShake;

    [Header("Wall Jump")]
    [SerializeField] private Transform wallCheck;
    bool isWallTouch;
    bool isWallSliding;

    bool isWallJumping;
    public float wallSlidingSpeed;
    public float wallJumpDuration;
    public Vector2 wallJumpForce;

    [SerializeField]
    private ParticleSystem footDust;

    private ParticleSystem.EmissionModule dustEmission;
    public float dustTimeOnAir = 0.1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSpriteObject = transform.Find("PlayerSprite").gameObject;
        anim = playerSpriteObject.GetComponent<Animator>();

        dustEmission = footDust.emission;

        //Attack
        slashAnim = attackSlash.GetComponent<Animator>();
    }

    private void Update()
    {
        //Attack
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (attackIsCoolDown == true)
            {
                anim.SetTrigger("idleAttack");
                slashAnim.SetTrigger("Attacked");

                AudioManager.instance.PlayRandomPitchSFX(2);

                StartCoroutine(PlayerAttackCoolDown(attackCoolDownTime));
            }
            else
            {
                Debug.Log("Wait!!!");
            }
        }

        //Move
        input = Input.GetAxisRaw("Horizontal");
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

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isWallTouch = Physics2D.OverlapCircle(wallCheck.position, checkRadius, whatIsGround);

        if (isWallTouch && !isGrounded && input != 0)
            isWallSliding = true;
        else
            isWallSliding = false;

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.velocity = Vector2.up * jumpForce;
                anim.SetTrigger("takeOff");
                dustTimeOnAir = 0.1f;

                AudioManager.instance.PlayRandomPitchSFX(1);
            }
            else if (isWallSliding)
            {
                isWallJumping = true;
                Invoke("stopWallJump", wallJumpDuration);
            }

        }

        //Jump animation
        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }


        //Foot dust particles
        if (input != 0 && isGrounded == true)
        {
            dustEmission.rateOverTime = 35f;
        }
        else if (isGrounded == false)
        {
            if (dustTimeOnAir > 0)
            {
                dustEmission.rateOverTime = 35f;
                dustTimeOnAir -= Time.deltaTime;
            }
            else if (dustTimeOnAir <= 0)
            {
                dustEmission.rateOverTime = 0f;
            }
        }
        else
        {
            dustEmission.rateOverTime = 0f;
        }


        if (input != 0 && isGrounded == true)
        {
            AudioManager.instance.PlayFootStep();
        }
    }

    private void FixedUpdate()
    {
        if (isWallSliding)
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));

        if (isWallJumping)
            rb.velocity = new Vector2(-input * wallJumpForce.x, wallJumpForce.y);
        /*  rb.AddForce(new Vector2(-horizontal * wallJumpForce.x * 0.1f, wallJumpForce.y * 0.1f), ForceMode2D.Impulse);*/

        else
            rb.velocity = new Vector2(input * speed, rb.velocity.y);

    }
    void stopWallJump()
    {
        isWallJumping = false;
    }


    IEnumerator PlayerAttackCoolDown(float coolDown)
    {
        attackIsCoolDown = false;

        yield return new WaitForSeconds(coolDown);

        attackIsCoolDown = true;
    }

    public void PlayCamShake()
    {
        camShake.GenerateImpulse();
    }

    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
    }
}
