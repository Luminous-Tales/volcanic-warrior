using UnityEngine;

public class PointsGain : MonoBehaviour
{
    private readonly int _pointsJump = 100;
    private readonly int _pointsAttack = 200;
    private readonly int _pointsDodge = 150;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("check point....");
        Debug.Log(gameObject.name);
        switch (gameObject.name)
        {

            case "skull(Clone)":
                if (collision.CompareTag("Player"))
                {
                    Debug.Log("skull point");
                    // Verifica se o player está caindo sobre o inimigo
                    Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
                    if (rb.linearVelocity.y < 0) // Verifica se está descendo
                    {
                        GameManager.instance.AddScore(_pointsJump); // Adiciona pontos
                        Destroy(gameObject); // Destroi o inimigo
                    }
                }
                break;

            case "ghost(Clone)":
                if (collision.CompareTag("Player"))
                {
                    Debug.Log("ghost point");
                    GameManager.instance.AddScore(_pointsAttack);
                }
                break;

            case "flying-demon(Clone)":
                if (collision.CompareTag("Player"))
                {
                    Debug.Log("fly point");

                    Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
                    if (rb.linearVelocity.y == 0 && rb.transform.position.y < transform.position.y) // O player está abaixo e não pulou
                    {
                        GameManager.instance.AddScore(_pointsDodge);
                    }
                }
                break;
        }

    }
}
