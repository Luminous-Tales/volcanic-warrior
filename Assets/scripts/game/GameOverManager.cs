using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Canvas gameOverScreen;
    public Canvas hudScreen;

    public void ShowGameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
        hudScreen.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Fechando o jogo");
    }
}
