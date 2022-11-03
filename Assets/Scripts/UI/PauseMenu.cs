using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : IngameMenu
{
    [SerializeField] GameObject pauseMenuPanel;
    public static bool gameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UsingMenu();
    }

    public override void UsingMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused == true)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pauseMenuPanel.SetActive(true);
        gameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void Quit()
    {
        pauseMenuPanel.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Setting()
    {

    }

    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1f;
    }
}
