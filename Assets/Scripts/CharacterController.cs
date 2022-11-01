using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    GameObject playerSpriteObject;

    public float speed;
    Rigidbody2D rb;
    bool facingRight = true;

    bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpforce;

    public Transform frontCheck;

    public float wallSlidingSpeed;

    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;

    [Header("Player splash attack")]
    [SerializeField] private GameObject attackSlash;
    [SerializeField] private Animator slashAnim;
    [SerializeField] private bool attackIsCoolDown = true;
    [SerializeField] private float attackCoolDownTime = 0.5f;
    public CinemachineImpulseSource camShake;



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
            if(attackIsCoolDown == true)
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

        // Dash
        
        //Move
        float input = Input.GetAxisRaw("Horizontal");
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

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
            anim.SetTrigger("takeOff");
            dustTimeOnAir = 0.1f;

            AudioManager.instance.PlayRandomPitchSFX(1);
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
