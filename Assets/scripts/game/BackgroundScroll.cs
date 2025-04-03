using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private MeshRenderer mr;
    private VelocityController gameController;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        gameController = FindFirstObjectByType<VelocityController>();
    }

    void Update()
    {
        if (gameController != null)
        {
            switch (gameObject.name)
            {
                case "ground":
                    float speed = gameController.CurrentSpeed * 0.07f;
                    mr.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
                    break;
                case "forest":
                    speed = gameController.CurrentSpeed * 0.04f;
                    mr.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
                    break;
                case "village":
                    speed = gameController.CurrentSpeed * 0.04f;
                    mr.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
                    break;
                case "mountain":
                    speed = gameController.CurrentSpeed * 0.01f;
                    mr.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
                    break;
                case "clouds":
                    speed = gameController.CurrentSpeed * 0.002f;
                    mr.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
                    break;
            }
        }
    }

}
