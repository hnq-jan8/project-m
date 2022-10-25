using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEnter : MonoBehaviour
{
    public string lastExitName;

    public GameObject sceneSwitchManager;
    public SceneSwitchManager sceneSwitchManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        sceneSwitchManager = GameObject.Find("Scene Switch Manager");
        sceneSwitchManagerScript = sceneSwitchManager.GetComponent<SceneSwitchManager>();

        if (PlayerPrefs.GetString("LatestExitName") == lastExitName && sceneSwitchManagerScript.switchedScene == true)
        {
            Debug.Log("Entered from " + lastExitName);
            PlayerSingleton.instance.transform.position = transform.position;
        }
    }
}
