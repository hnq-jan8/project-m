using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string sceneToLoad;
    public string exitName;

    public GameObject sceneSwitchManager;
    public SceneSwitchManager sceneSwitchManagerScript;

    private void Start()
    {
        sceneSwitchManager = GameObject.Find("Scene Switch Manager");
        sceneSwitchManagerScript = sceneSwitchManager.GetComponent<SceneSwitchManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            sceneSwitchManagerScript.switchedScene = true;
            PlayerPrefs.SetString("LatestExitName", exitName);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
