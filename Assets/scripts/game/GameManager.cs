using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("game");
    }

    public void OpenConfiguration()
    {
        //TODO: Adicionar l�gica para abrir op��es
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
