using System.Collections;
using TMPro;
using UnityEngine;

public class Play : MonoBehaviour
{
    public GameObject ground;
    public GameObject player;
    public GameObject background;

    public GameObject[] enemys;

    public TextMeshProUGUI pts;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI distanceText;

    public float speed = 5f;
    private float elapsedTime = 0f;
    private bool isGameOver = false;
    private float distance;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
        if (isGameOver) return;

        elapsedTime += Time.deltaTime;
        timeText.text = elapsedTime.ToString("F2") + "s";

        distance = elapsedTime * speed;
        distanceText.text = distance.ToString("F2") + "m";
    }

    IEnumerator SpawnEnemy()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(5);

            if (enemys.Length > 0)
            {
                int randomIndex = Random.Range(0, enemys.Length);
                GameObject newEnemy = Instantiate(enemys[randomIndex]);
                Destroy(newEnemy, 5f);
            }
        }
    }

    public void OnGameOver()
    {
        isGameOver = true;
        StopAllCoroutines();

        float bestDistance = PlayerPrefs.GetFloat("BestDistance", 0);
        float currentDistance = elapsedTime * speed;

        if (currentDistance > bestDistance)
        {
            PlayerPrefs.SetFloat("BestDistance", currentDistance);
            PlayerPrefs.Save();
        }
    }
}
