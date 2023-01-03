using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : PlayerBehavior
{
    [Header("Animations")]
    [SerializeField] private GameObject spriteObject;
    [SerializeField] private Animator anim;

    [SerializeField] private GameObject attackSlash;
    [SerializeField] private Animator slashAnim;
    [Header("Stats")]
    [SerializeField] private bool attackIsCoolDown = true;
    [SerializeField] private float attackCoolDownTime;

    // Start is called before the first frame update
    void Start()
    {
        anim = spriteObject.GetComponent<Animator>();

        slashAnim = attackSlash.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(UIUsingCheck() == false)
        {
            Attacking();
        }
    }

    void Attacking()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (attackIsCoolDown == true)
            {
                anim.SetTrigger("idleAttack");
                slashAnim.SetTrigger("Attacked");

                //AudioManager.instance.PlayRandomPitchSFX(2);

                StartCoroutine(PlayerAttackCoolDown(attackCoolDownTime));
            }
            else
            {
                Debug.Log("Wait!!!");
            }
        }
    }

    IEnumerator PlayerAttackCoolDown(float coolDown)
    {
        attackIsCoolDown = false;

        yield return new WaitForSeconds(coolDown);

        attackIsCoolDown = true;
    }
}
