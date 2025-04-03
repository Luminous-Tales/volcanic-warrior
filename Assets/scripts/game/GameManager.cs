using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas pauseScreen;
    public Canvas HUD;
    public Canvas Setting;
    private bool isPause;

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("game");
    }

    public void TogglePause()
    {
        isPause = !isPause;

        if (isPause)
        {
            HUD.gameObject.SetActive(false);
            pauseScreen.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            HUD.gameObject.SetActive(true);
            pauseScreen.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void RestartGame()
    {
        TogglePause();
        SceneManager.LoadScene("game");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void ResumeGame()
    {
        HUD.gameObject.SetActive(true);
        pauseScreen.gameObject.SetActive(false);
        TogglePause();
    }

    public void SettingsOpen()
    {

        pauseScreen.gameObject.SetActive(false);
        Setting.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
