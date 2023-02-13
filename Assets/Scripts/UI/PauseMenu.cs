using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour, IIngameUI
{
    //[SerializeField] GameObject pauseMenuPanel;
    public static bool gameIsPaused = false;
    [SerializeField] private KeyCode keyCode;

    // Start is called before the first frame update
    void Start()
    {
        //pauseMenuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool UseUI(GameObject panel)
    {
        //Debug.LogError("Paused");
        if (Input.GetKeyDown(keyCode))
        {
            if (gameIsPaused == true)
            {
                Resume(panel);
            }
            else
            {
                PauseGame(panel);    
            }
        }
        return gameIsPaused;
    }

    void PauseGame(GameObject panel)
    {
        panel.SetActive(true);
        gameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void Quit(GameObject panel)
    {
        panel.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1f;
        CameraSingleton.instance.DestroySelf();
        MustHaveSingleton.instance.DestroySelf();
        SceneManager.LoadScene("Menu");
    }

    public void Setting()
    {

    }

    public void Resume(GameObject panel)
    {
        panel.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1f;
    }
}
