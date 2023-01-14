using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HnRBehavior : MonoBehaviour
{
    //States
    public IdleState_HnR idleState = new IdleState_HnR();
    public DetectState_HnR detectState = new DetectState_HnR();
    public ChaseState_HnR chaseState = new ChaseState_HnR();
    public AttackState_HnR attackState = new AttackState_HnR();
    public RunState_HnR runState = new RunState_HnR();
   

    public IHnR currenState;

    //Player info
    public LayerMask playerLayer { get; private set; }
    public GameObject player { get; private set; }

    //Animation
    public Animator anim { get; private set; }

    //Behavior
    public SideMove move { get; private set; }
    public Flip flip { get; private set; }
    public Dash dash { get; private set; }


    private void OnEnable()
    {
        currenState = idleState;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Player
        player = GameObject.FindObjectOfType<PlayerSingleton>().gameObject;
        playerLayer = LayerMask.GetMask("Player");

        //Behavior
        move = GetComponentInChildren<SideMove>();
        flip = GetComponentInChildren<Flip>();
    }

    // Update is called once per frame
    void Update()
    {
        currenState = currenState.DoState(this);
    }
}
