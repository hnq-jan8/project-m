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
            Debug.LogError("Awake called and exists another instance");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Awake called and exists no other instance");
            instance = this;
            SceneManager.sceneLoaded += InvokeSceneLoadEvent;
        }
        DontDestroyOnLoad(gameObject);
    }

    void InvokeSceneLoadEvent(Scene current, LoadSceneMode mode)
    {
        Debug.LogError("Load scene called");
        OnSceneLoaded.Invoke();
    }
}
