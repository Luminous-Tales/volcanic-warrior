using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Canvas pauseScreen;

    public void StartGame()
    {
        SceneManager.LoadScene("game");
    }

    public void OpenConfiguration()
    {
        pauseScreen.gameObject.SetActive(true);
    }

    public void CloseConfiguration()
    {
        pauseScreen.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
