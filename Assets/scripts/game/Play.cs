using System.Collections;
using TMPro;
using UnityEngine;

public class Play : MonoBehaviour
{
    public GameObject ground;
    public GameObject player;
    public GameObject background;
    private VelocityController gameController;

    public GameObject[] enemys;

    public TextMeshProUGUI pts;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI distanceText;

    public float speed = 5f;
    public float acceleration = 0.1f;
    private float elapsedTime = 0f;
    private bool isGameOver = false;

    void Start()
    {
        gameController = Object.FindFirstObjectByType<VelocityController>();
        StartCoroutine(SpawnEnemy());

    }

    void Update()
    {
        if (isGameOver) return;

        elapsedTime += Time.deltaTime;
        timeText.text = elapsedTime.ToString("F2");

        float distance = elapsedTime * gameController.CurrentSpeed;
        distanceText.text = distance.ToString("F2");
    }

    IEnumerator SpawnEnemy()
    {
        while (!isGameOver)
        {
            float spawnRate = Mathf.Max(1f, 5f - gameController.CurrentSpeed * 0.2f);
            yield return new WaitForSeconds(spawnRate);

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
        gameController.GameOver();
        
        GameDataManager.instance.SaveGameData(
            PointsManager.instance.score,
            elapsedTime,
            elapsedTime * gameController.CurrentSpeed
        );
    }
}
