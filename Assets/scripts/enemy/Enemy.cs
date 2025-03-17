using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private VelocityController gameController;
    private Rigidbody2D rb;

    void Start()
    {
        gameController = Object.FindFirstObjectByType<VelocityController>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (gameController != null)
        {
            rb.linearVelocity = new Vector2(-gameController.CurrentSpeed * 2, rb.linearVelocity.y);
        }
    }
}

