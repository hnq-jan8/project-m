using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void QuitGame()
    {
        Debug.Log("Alo");
        Application.Quit();
    }
}
