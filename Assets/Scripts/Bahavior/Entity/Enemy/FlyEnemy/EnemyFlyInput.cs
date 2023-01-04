using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyInput : MonoBehaviour, IFlyInput
{
    public Vector2 target { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerSingleton>().transform.position;
    }

    private void Update()
    {
        target = FindObjectOfType<PlayerSingleton>().transform.position;
    }
}
