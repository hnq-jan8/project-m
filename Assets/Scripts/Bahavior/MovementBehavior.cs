using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField] protected GameObject movingObject;
    [SerializeField] protected Rigidbody2D rb;

    private void Start()
    {
        if(movingObject == null)
        {
            Debug.LogError("Please insert a moving object for the game object: " + this.gameObject.name);
        }
        rb = movingObject.GetComponent<Rigidbody2D>();
    }
}
