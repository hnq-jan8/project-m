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
        Debug.LogError("ABC");
        OnSceneLoaded.Invoke();
        //SetUpSceneCamera();
    }

    void SetUpSceneCamera()
    {
        //Cam find player target to follow
        foreach(CamFindFollowTarget cam in FindObjectsOfType<CamFindFollowTarget>())
        {
            cam.FindTargetToFollow();
        }

        //Cam position find player target
        foreach(CameraPosition cam in FindObjectsOfType<CameraPosition>())
        {
            cam.FindPlayer();
        }
    }
}
