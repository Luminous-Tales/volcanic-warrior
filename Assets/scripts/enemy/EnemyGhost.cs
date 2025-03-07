using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhost : Enemy
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("hitbox"))
        {
            Destroy(gameObject);
        }
    }
}
