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
        SceneManager.LoadScene("LoadingScene");
    }

    public void OpenSettingMenu(GameObject settingMenu)
    {
        settingMenu.SetActive(true);
    }

    public void CloseSettingMenu(GameObject settingMenu)
    {
        settingMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Alo");
        Application.Quit();
    }
}
