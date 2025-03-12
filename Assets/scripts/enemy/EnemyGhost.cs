using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhost : Enemy
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("hitbox"))
        {
            Destroy(gameObject);
        }
    }
}
