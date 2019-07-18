using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PostEffect : MonoBehaviour {

    // public Shader shader;
    public Material mat;

    public void Initialize(Material mat)
    {
        this.mat = mat;
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest )
    {
        Graphics.Blit (src, dest, this.mat);
    }
}