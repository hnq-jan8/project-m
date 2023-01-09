using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyBehavior : MonoBehaviour
{
    public FlyAbstractState currentState;

    //States
    public FlyEnemyIdleState idleState = new FlyEnemyIdleState();
    public FlyEnemyDetectState detectState = new FlyEnemyDetectState();
    public FlyEnemyChaseState chaseState = new FlyEnemyChaseState();

    //Player info
    public LayerMask playerLayer { get; private set; }
    public GameObject player { get; private set; }

    //Animation
    public Animator anim { get; private set; }

    //RigidBody
    public Rigidbody2D rb { get; private set; }

    //Fly behavior
    public Fly fly { get; private set; }

    //Flip behavior
    public Flip flip { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        currentState = idleState;

        //Player
        player = GameObject.FindObjectOfType<PlayerSingleton>().gameObject;     //Find an object that has an unique component (singleton in this case)
        playerLayer = LayerMask.GetMask("Player");

        //RigidBody
        rb = GetComponent<Rigidbody2D>();

        //Fly behavior
        fly = GetComponentInChildren<Fly>();

        //Flip behavior
        flip = GetComponentInChildren<Flip>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.DoState(this);
    }
}

