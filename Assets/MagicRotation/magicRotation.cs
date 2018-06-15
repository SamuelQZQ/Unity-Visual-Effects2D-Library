using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicRotation : MonoBehaviour {

	public Material mtl;
	public float rot;

	void Update()
	{
		rot += 0.1f;
	}

	//  called after all rendering is complete to render image.
	void OnRenderImage(RenderTexture src, RenderTexture dest) 
	{
		if (rot == 0.0)
			return;
		mtl.SetFloat("_Rot", rot);

		// Copies source texture into destination render texture with a shader
		Graphics.Blit(src, dest, mtl); 
	}
}
