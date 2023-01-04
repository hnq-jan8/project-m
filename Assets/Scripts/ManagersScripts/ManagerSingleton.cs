using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ManagerSingleton : MonoBehaviour
{
    public static ManagerSingleton instance;

    public UnityEvent OnSceneLoaded;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            SceneManager.sceneLoaded += InvokeSceneLoadEvent;
        }
        DontDestroyOnLoad(gameObject);
    }

    void InvokeSceneLoadEvent(Scene current, LoadSceneMode mode)
    {
        OnSceneLoaded.Invoke();
    }
}
