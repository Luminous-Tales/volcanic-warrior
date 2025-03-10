using UnityEngine;

public class PointsGain : MonoBehaviour
{
    private readonly int _pointsJump = 100;
    private readonly int _pointsAttack = 200;
    private readonly int _pointsDodge = 150;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (gameObject.name)
        {
            case "ghost(Clone)":
                if (collision.CompareTag("hitbox"))
                {
                    GameManager.instance.AddScore(_pointsAttack);
                }
                break;

            case "PointBox":
                if (collision.CompareTag("Player") && transform.parent.name == "flying-demon(Clone)")
                {
                    GameManager.instance.AddScore(_pointsDodge);
                }
                else if (collision.CompareTag("Player") && transform.parent.name == "skull(Clone)")
                {
                    GameManager.instance.AddScore(_pointsJump);
                }

                    break;
        }

    }
}
