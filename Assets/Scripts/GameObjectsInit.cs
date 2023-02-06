using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameObjectsInit : MonoBehaviour
{
    public static GameObjectsInit instance;

    [SerializeField] private List<GameObject> mustHaveObjects;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            //Debug.LogError("ABC");
            instance = this;
            SceneManager.sceneLoaded += InvokeSceneLoadEvent;
        }
        DontDestroyOnLoad(gameObject);
    }

    void InvokeSceneLoadEvent(Scene current, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "Menu") return;

        foreach (GameObject mustHave in mustHaveObjects)
        {
            Instantiate(mustHave);
        }

        instance = null;
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
