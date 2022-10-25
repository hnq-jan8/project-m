using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDespawn : MonoBehaviour
{
    private ParticleSystem particleSystemComponent;
    private float maxLifeTime;

    private void Start()
    {
        particleSystemComponent = GetComponent<ParticleSystem>();
        maxLifeTime = particleSystemComponent.main.startLifetime.constantMax + 1f;
    }

    // Update is called once per frame
    void Update()
    {
        maxLifeTime -= Time.deltaTime;
        if(maxLifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
