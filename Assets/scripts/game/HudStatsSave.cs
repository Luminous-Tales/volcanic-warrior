using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudStatsSave : MonoBehaviour
{
    private Slider barHealt;
    
    private TextMeshProUGUI distance;
    private TextMeshProUGUI time;
    private TextMeshProUGUI points;

    private GameDataManager gameDataManager;

    void Start()
    {
        if (time == null) time = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();
        if (barHealt == null) barHealt = GameObject.Find("BarHealt").GetComponent<Slider>();
        if (distance == null) distance = GameObject.Find("Distance").GetComponent<TextMeshProUGUI>();
        if (points == null) points = GameObject.Find("Points").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (barHealt.value <= 0)
        {
            SaveStats();
        }
    }

    private void SaveStats()
    {
        gameDataManager.SaveElapsedTime(float.Parse(time.text));
        gameDataManager.SaveDistance(float.Parse(distance.text));
        gameDataManager.SaveScore(int.Parse(points.text));
    }
}
