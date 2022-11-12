using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string sceneToLoad;
    public string exitName;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SceneSwitchManager.switchedScene = true;
            PlayerPrefs.SetString("LatestExitName", exitName);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
