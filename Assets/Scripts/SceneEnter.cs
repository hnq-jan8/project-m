using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEnter : MonoBehaviour
{
    public string lastExitName;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("LatestExitName") == lastExitName && SceneSwitchManager.switchedScene == true)
        {
            Debug.Log("Entered from " + lastExitName);
            PlayerSingleton.instance.transform.position = transform.position;
        }
    }
}
