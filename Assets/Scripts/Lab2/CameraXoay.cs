using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraXoay : MonoBehaviour
{
    public float tocDoCamera;// tốc độ xoay của bg
    
    private Renderer _renderer;
  
    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();// lấy thuộc tính của MeshRenderer

    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Repeat(Time.time * tocDoCamera, 1);
        Vector2 offset = new Vector2(x, 0);
        _renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
