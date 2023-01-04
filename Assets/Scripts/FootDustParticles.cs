using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootDustParticles : MonoBehaviour
{
    public GameObject movingObject;
    [SerializeField] private ParticleSystem footDustParticle;
    private ParticleSystem.EmissionModule dustEmission;
    [SerializeField] float dustTimeOnAir = 0.1f;
    [SerializeField] MovementBehavior movementBehavior;
    [SerializeField] Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        footDustParticle = GetComponent<ParticleSystem>();
        dustEmission = footDustParticle.emission;

        lastPos = movingObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnFootDust();
    }

    bool IsMoving()
    {
        Vector3 offset = movingObject.transform.position - lastPos;
        if (offset.x > 0.0f || offset.x < 0.0f)
        {
            lastPos = movingObject.transform.position;
            return true;
        }
        return false;
    }

    void DustTimeOnAirReset()
    {
        if(movementBehavior.IsGrounded() == true)
        {
            dustTimeOnAir = 0.1f;
        }
    }

    void SpawnFootDust()
    {
        if(movementBehavior == null)
        {
            if(IsMoving() == true)
            {
                dustEmission.rateOverTime = 35f;
            }
            else
            {
                dustEmission.rateOverTime = 0f;
            }
        }
        else
        {
            DustTimeOnAirReset();
            if (IsMoving() == true && movementBehavior.IsGrounded() == true)
            {
                dustEmission.rateOverTime = 35f;
            }
            else if (movementBehavior.IsGrounded() == false)
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
        }
    }
}
