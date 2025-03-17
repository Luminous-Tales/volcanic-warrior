using UnityEngine;

public class VelocityController : MonoBehaviour
{
    public float baseSpeed = 1f;
    public float maxSpeed = 10f;
    public float acceleration = 0.1f;

    public float CurrentSpeed { get; private set; }

    private bool isGameOver = false;

    void Start()
    {
        CurrentSpeed = baseSpeed;
    }

    void Update()
    {
        if (!isGameOver)
        {
            CurrentSpeed = Mathf.Min(CurrentSpeed + (acceleration * Time.deltaTime), maxSpeed);
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        CurrentSpeed = 0;
    }
}
