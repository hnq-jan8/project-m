using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSideMoveInput : MonoBehaviour, ISideMovementInput
{
    public float input { get; private set; }

    [SerializeField] private Transform player;
    [SerializeField] private float offset;

    private void Start()
    {
        player = PlayerSingleton.instance.transform;
    }

    private void Update()
    {
        //ChasePlayer();
    }

    public void StopChasing()
    {
        input = 0;
        //Debug.Log(input);
    }

    public void UpdateInput()
    {
        if (transform.position.x - offset > player.position.x)        //Player is to the left
        {
            input = -1;
            //Debug.Log(input);
        }
        else if (transform.position.x + offset < player.position.x)   //Player is to the right
        {
            input = 1;
            //Debug.Log(input);
        }
        else                                               //Player is at the same position with transform
        {
            input = 0;
            //Debug.LogError(input);
        }
    }
}
