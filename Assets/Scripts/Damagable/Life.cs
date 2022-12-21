using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class Life : MonoBehaviour
{
    [SerializeField] private int health;    //Number of hits taken to die

    [Header("Sound effects (indexes from sound manager)")]
    //0: Hurt sound
    //1: Normal sound               // These are the indexes of the below elements (aranged in order)
    //2: Death sound
    //3: ...
    [SerializeField] private int hurtSound;
    [SerializeField] private int deathSound;


    [Header("Particle effects")]
    [SerializeField] private int[] hurtParticles;
    [SerializeField] private int deathParticles;

    [Header("AttackFX")]
    [SerializeField] private GameObject attackFx;

    [Header("Sprite (Tint when damaged)")]
    [SerializeField] private GameObject sprite;
    [SerializeField] private SpriteRenderer[] spriteRenderers;
    [SerializeField] private MeshRenderer spineMeshRenderer;
    [SerializeField] private Color originalSpineColor;
    [SerializeField] private Color tintSpineColor;
    [SerializeField] private Color originalSpriteColor;
    [SerializeField] private Color tintSpriteColor;

    [Header("Corpse and drops (appear when object dies)")]
    [SerializeField] private GameObject[] corpse;
    [SerializeField] private GameObject[] drops;

    [Header("Damage trigger tag")]
    [SerializeField] private string triggerTag;
    private ILife lifeBehavior;

    private void Start()
    {
        lifeBehavior = GetComponent<ILife>();

        //Trigger tag
        triggerTag = lifeBehavior.triggerDamageTag;
        if (triggerTag == null || triggerTag == "")
        {
            Debug.Log("TriggerTag is null");
        }


        //Tint material
        if(spriteRenderers.Length == 0 && spineMeshRenderer == null)
        {
            Debug.LogError("Please insert SPRITE RENDERER(S) or SPINE MECHANIM for the object: " + this.gameObject);
        }

        //Attack FX
        if (attackFx == null)
        {
            Debug.LogError("Please insert ATTACK FX to the object: " + this.gameObject);
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public void TakeDamage(int damageTaken)
    {
        //Hurt sound
        if(AudioManager.instance != null)
        {
            AudioManager.instance.PlayRandomPitchSFX(hurtSound);    //Play the hurt sound of the entity (because 0 is the index of this entity hurt sound element in the Audio Manager)
        }

        //Hurt particles
        if (ParticlesManager.instance != null)
        {
            foreach (int hurtParticle in hurtParticles)
            {
                ParticlesManager.instance.SpawnParticle(hurtParticle, transform.position);
            }
        }

        health = health - damageTaken;
    }

    public void Die()
    {
        if (ParticlesManager.instance != null)
        {
            ParticlesManager.instance.SpawnParticle(deathParticles, transform.position);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(triggerTag))
        {
            GameObject thePlayer = null;
            if (triggerTag == "Attack")     //If this is attacked by player
            {
                thePlayer = collision.gameObject.transform.root.gameObject; //Parent of parent of parent
            }

            //Take damage
            int damage = collision.gameObject.GetComponent<Damage>().GetDamage();
            TakeDamage(damage);

            //Camshake
            GameObject theCamshake = null;
            if (thePlayer != null)
            {
                theCamshake = thePlayer.transform.Find("Camshake").gameObject;
                theCamshake.GetComponent<Camshake>().PlayCamShake();
            }

            //Tint when damaged
            if(spriteRenderers.Length > 0)
            {
                foreach(SpriteRenderer renderer in spriteRenderers)
                {
                    renderer.material.SetColor("_Tint", tintSpriteColor);
                }
            }
            else if(spineMeshRenderer != null)
            {
                MaterialPropertyBlock mpb = new MaterialPropertyBlock();
                mpb.SetColor("_Black", tintSpineColor);
                spineMeshRenderer.SetPropertyBlock(mpb);
            }

            //Spawn attack FX
            if(attackFx != null)
            {
                Instantiate(attackFx, transform.position, Quaternion.Euler(0, Random.Range(0, 4) * 90, 0));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Reset tint color
        if (spriteRenderers.Length > 0)
        {
            foreach (SpriteRenderer renderer in spriteRenderers)
            {
                renderer.material.SetColor("_Tint", originalSpriteColor);
            }
        }
        else if (spineMeshRenderer != null)
        {
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();
            mpb.SetColor("_Black", originalSpineColor);
            spineMeshRenderer.SetPropertyBlock(mpb);
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
