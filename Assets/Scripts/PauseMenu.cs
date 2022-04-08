using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuPauseUI;
    public GameObject settingsWindow;
   public static bool gameIsPaused = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        PlayerMovement.instance.enabled = false;
        menuPauseUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }
    public void Resume()
    {
        PlayerMovement.instance.enabled = true;
        menuPauseUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }
    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("Main Menu");
    }
    public void CloseSettingsMenu()
    {
        settingsWindow.SetActive(false);
    }
    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }
}
