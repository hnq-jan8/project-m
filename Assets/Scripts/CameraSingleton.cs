using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSingleton : MonoBehaviour
{
    public static CameraSingleton instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
