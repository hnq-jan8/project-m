using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    public static ParticlesManager instance;

    public GameObject[] particles;

    private void Start()
    {
        instance = this;
    }

    public void SpawnParticle(int particleToSpawn, Vector3 whereToSpawn)
    {
        Instantiate(particles[particleToSpawn], whereToSpawn, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
