using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int health;    //Number of hits taken to die

    [Header("Sound effects (indexes from sound manager)")]
    //0: Hurt sound
    //1: Normal sound               // These are the indexes of the below elements (aranged in order)
    //2: Death sound
    //3: ...
    [SerializeField] private int hurtSound;
    [SerializeField] private int deathSound;


    [Header("Particle effects")]
    [SerializeField] private int hurtParticles;
    [SerializeField] private int deathParticles;

    private void Start()
    {
        
    }

    public void TakeDamage(int damageTaken)
    {
        AudioManager.instance.PlayRandomPitchSFX(hurtSound);    //Play the hurt sound of the entity (because 0 is the index of this entity hurt sound element in the Audio Manager)
        health = health - damageTaken;
    }

    public virtual void Die()
    {
        ParticlesManager.instance.SpawnParticle(deathParticles, transform.position);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player Attack")
        {
            GameObject thePlayer = collision.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject; //Parent of parent of parent

            //Get damage
            GameObject theDamage = thePlayer.transform.Find("Damage").gameObject;
            int playerDamage = theDamage.GetComponent<Damage>().GetDamage();
            Debug.Log(playerDamage);

            //Camshake
            GameObject theCamshake = thePlayer.transform.Find("Camshake").gameObject;
            theCamshake.GetComponent<Camshake>().PlayCamShake();
            
            //Particles
            ParticlesManager.instance.SpawnParticle(hurtParticles, transform.position);
            TakeDamage(playerDamage);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player Attack")
        {
            Debug.Log("exit");
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }
}
