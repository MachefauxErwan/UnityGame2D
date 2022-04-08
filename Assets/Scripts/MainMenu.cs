using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;

    public GameObject settingsWindow;
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsMenu()
    {
        settingsWindow.SetActive(false);
    }

    public void LoadCreditScene()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
