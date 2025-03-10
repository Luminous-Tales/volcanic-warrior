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
        //TODO: Adicionar lógica para abrir opções
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
