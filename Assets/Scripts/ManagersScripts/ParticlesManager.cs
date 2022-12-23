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

    public GameObject SpawnParticle(int particleToSpawn, Vector3 whereToSpawn)
    {
        return Instantiate(particles[particleToSpawn], whereToSpawn, Quaternion.identity);
    }

    public GameObject SpawnDirectionalParticle(int particleToSpawn, Vector3 whereToSpawn, Quaternion direction)
    {
        return Instantiate(particles[particleToSpawn], whereToSpawn, direction);
    }

    public void setParticleColor(ParticleSystem particle, Color baseColor)
    {
        Debug.Log("a");
        Color adjustedColor = new (baseColor.r - 0.1f, baseColor.r - 0.1f, baseColor.r - 0.1f, 1);

        ParticleSystem.MainModule mainModule = particle.main;
        mainModule.startColor = new ParticleSystem.MinMaxGradient(baseColor, adjustedColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
