using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class RaidData
{
    public string raid;
    public float time;
    public int score;
    public float meters;
}

[System.Serializable]
public class ScoreHistory
{
    public List<RaidData> historic = new List<RaidData>();
}

public class ScoreManager : MonoBehaviour
{
    private string saveFile;
    private ScoreHistory scoreHistory = new ScoreHistory();

    void Start()
    {
        saveFile = Path.Combine(Application.persistentDataPath, "scoreHistory.json");
        LoadScores();
    }

    public void SaveScore(float time, int score, float meters)
    {
        // Criar um novo registro
        RaidData newRaid = new RaidData
        {
            raid = "raid" + (scoreHistory.historic.Count + 1),
            time = time,
            score = score,
            meters = meters
        };

        scoreHistory.historic.Add(newRaid);

        string json = JsonUtility.ToJson(scoreHistory, true);
        File.WriteAllText(saveFile, json);

        Debug.Log("Pontuação salva: " + json);
    }

    public void LoadScores()
    {
        try
        {
            if (File.Exists(saveFile))
            {
                string json = File.ReadAllText(saveFile);
                scoreHistory = JsonUtility.FromJson<ScoreHistory>(json);
                Debug.Log("Histórico carregado: " + json);
            }
            else
            {
                Debug.Log("Nenhum histórico encontrado, criando novo.");
                scoreHistory = new ScoreHistory();
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Erro ao carregar o histórico: " + ex.Message);
            scoreHistory = new ScoreHistory();
        }
    }

    public RaidData GetBestScore()
    {
        if (scoreHistory.historic.Count == 0)
            return null;

        // Encontrar o melhor score
        RaidData best = scoreHistory.historic[0];
        foreach (RaidData raid in scoreHistory.historic)
        {
            if (raid.score > best.score)
                best = raid;
        }
        return best;
    }
}
