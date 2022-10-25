using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Health and Damage")]
    [SerializeField] int health;    //Number of hits taken to die
    [SerializeField] int damage;

    [Header("Sound effects")]
    //0: Hurt sound
    //1: Normal sound               // These are the indexes of the below elements (aranged in order)
    //2: Death sound
    //3: ...
    [SerializeField] int[] soundEffectIndexes;  // the elements in this array is the sound indexes in the Audio Manager


    [Header("Particle effects")]
    [SerializeField] int[] particleEffectIndexes;
    public void TakeDamage(int damageTaken)
    {
        AudioManager.instance.PlayRandomPitchSFX(soundEffectIndexes[0]);    //Play the hurt sound of the entity (because 0 is the index of this entity hurt sound element in the Audio Manager)
        health = health - damageTaken;
    }

    public int GetDamage()
    {
        return damage;
    }

    public virtual void Die()
    {
        ParticlesManager.instance.SpawnParticle(0, transform.position);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player Attack")
        {
            GameObject thePlayer = collision.gameObject.transform.parent.gameObject.transform.parent.gameObject; //Parent of parent
            int playerDamage = thePlayer.GetComponent<PlayerEntity>().GetDamage();
            Debug.Log(playerDamage);
            thePlayer.GetComponent<CharacterController>().PlayCamShake();
            ParticlesManager.instance.SpawnParticle(1, transform.position);
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
