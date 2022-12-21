using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightActivateArea : MonoBehaviour
{
    public bool fightActivated { get; private set; }
    public bool fightInProgress { get; private set; }
    [SerializeField] Transform pointA, pointB;
    [SerializeField] LayerMask playerLayer;

    private void Start()
    {
        fightActivated = false;
        fightInProgress = false;
    }

    private void Update()
    {
        if(Physics2D.OverlapArea(pointA.position, pointB.position, playerLayer))
        {
            fightActivated = true;
        }
    }

    public void setFightInprogress()
    {
        fightInProgress = true;
    }
}
