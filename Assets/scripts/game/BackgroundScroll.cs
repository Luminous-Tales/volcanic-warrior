using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public MeshRenderer mr;
    private VelocityController gameController;

    void Start()
    {
        gameController = Object.FindFirstObjectByType<VelocityController>();
    }

    void Update()
    {
        if (gameController != null)
        {
            float speed = gameController.CurrentSpeed * 0.1f;
            mr.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
        }
    }

}
