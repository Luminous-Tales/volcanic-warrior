using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Canvas hudScreen;

    private TextMeshProUGUI finalScoreText;
    private TextMeshProUGUI finalTimeText;
    private TextMeshProUGUI finalDistanceText;

    private void Start()
    {
        finalDistanceText = transform.Find("distance").GetComponent<TextMeshProUGUI>();
        finalScoreText = transform.Find("points").GetComponent<TextMeshProUGUI>();
        finalTimeText = transform.Find("time").GetComponent<TextMeshProUGUI>();

        // GameDataManager.instance.LoadGameData();


    }
    public void ShowGameOver()
    {
        gameObject.SetActive(true);
        hudScreen.gameObject.SetActive(false);
        Time.timeScale = 0f;

        finalScoreText.text = GameDataManager.instance.score.ToString();
        finalTimeText.text = GameDataManager.instance.time.ToString();
        finalDistanceText.text = GameDataManager.instance.distance.ToString();
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
