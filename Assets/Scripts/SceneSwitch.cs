using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string sceneToLoad;
    public string exitName;
    [SerializeField] private bool isStructure;
    [SerializeField] private bool canEnter;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(isStructure == true && canEnter == false)
            {
                canEnter = true;
            }
            else
            {
                SceneSwitchManager.switchedScene = true;
                PlayerPrefs.SetString("LatestExitName", exitName);
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (isStructure == true && canEnter == true)
            {
                canEnter = false;
            }
        }
    }

    private void Update()
    {
        if(canEnter == true && Input.GetKeyDown(KeyCode.Space))
        {
            SceneSwitchManager.switchedScene = true;
            PlayerPrefs.SetString("LatestExitName", exitName);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
