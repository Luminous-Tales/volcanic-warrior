using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager instance;

    public int score;
    public float time;
    public float distance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SaveGameData(int newScore, float newTime, float newDistance)
    {
        score = newScore;
        time = newTime;
        distance = newDistance;

        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetFloat("Time", time);
        PlayerPrefs.SetFloat("Distance", distance);
        PlayerPrefs.Save();

    }

    public void SaveScore(int newScore)
    {
        score = newScore;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    public void SaveElapsedTime(float newTime)
    {
        time = newTime;
        PlayerPrefs.SetFloat("Time", time);
        PlayerPrefs.Save();
    }

    public void SaveDistance(float newDistance)
    {
        distance = newDistance;
        PlayerPrefs.SetFloat("Distance", distance);
        PlayerPrefs.Save();
    }

    public void LoadGameData()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        time = PlayerPrefs.GetFloat("ElapsedTime", 0f);
        distance = PlayerPrefs.GetFloat("Distance", 0f);
    }
}
