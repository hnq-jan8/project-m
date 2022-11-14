using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjectSingleton : MonoBehaviour
{
    public static MapObjectSingleton instance;

    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}
