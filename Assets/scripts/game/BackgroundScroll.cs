using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public MeshRenderer mr;
    public float speed; 

    void Update()
    {
        mr.material.mainTextureOffset = new Vector2(Mathf.Repeat(mr.material.mainTextureOffset.x + speed * Time.deltaTime, 1), 0);
    }
}
