using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class InkEffect : MonoBehaviour
{
    public RenderTexture PreviousFrameBuffer;
    public Material InkBleedMaterial;

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        RenderTexture temp = RenderTexture.GetTemporary(src.width, src.height, 0);

        InkBleedMaterial.SetTexture("_PrevFrame", PreviousFrameBuffer);
        Graphics.Blit(src, temp, InkBleedMaterial);
        Graphics.Blit(temp, PreviousFrameBuffer);
        Graphics.Blit(temp, dst);

        RenderTexture.ReleaseTemporary(temp);
    }
}