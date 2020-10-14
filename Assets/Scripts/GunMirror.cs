using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMirror : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Camera _mirrorCamera;
    private RenderTexture rt;

    void  Start()
    {
        rt = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
        rt.Create();
        _mirrorCamera.targetTexture = rt;
        var newMat = new Material(Shader.Find("Diffuse")) {mainTexture = rt};
        _renderer.material = newMat;
    }
}
