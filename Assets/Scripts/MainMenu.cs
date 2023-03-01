using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private bool loadDemoScene = false;
    private void Awake()
    {

    }
    public void StartGame()
    {
        if(loadDemoScene == true)
        {
            SceneManager.LoadScene("LoadingDemoScene");
            return;
        }
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

    public void ToggleDemo()
    {
        loadDemoScene = !loadDemoScene;
    }
}
