using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MustHaveSingleton : MonoBehaviour
{
    public static MustHaveSingleton instance;

    // Start is called before the first frame update
    /*void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }*/

    private void OnEnable()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void DestroySelf()
    {
        instance = null;
        Destroy(this.gameObject);
    }
}
