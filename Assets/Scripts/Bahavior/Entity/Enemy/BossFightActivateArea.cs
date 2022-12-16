using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightActivateArea : MonoBehaviour
{
    public bool fightActivated { get; private set; }

    private void Start()
    {
        fightActivated = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fightActivated = true;
        }
    }
}
