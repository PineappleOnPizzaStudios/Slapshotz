using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public string SceneToLoad;
    public string MainMenuScene;
    public GameObject PauseMenu;
    public GameObject PauseButton;
    public void PauseGame()
    {
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
        PauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneToLoad);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(MainMenuScene);  
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
