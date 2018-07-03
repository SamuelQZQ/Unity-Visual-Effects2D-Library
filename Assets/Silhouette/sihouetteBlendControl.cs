using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sihouetteBlendControl : MonoBehaviour {

    public Material mat;
    private float blend = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        blend += Time.time * 0.005f;
        if (blend > 1f) blend = 1f;
        mat.SetFloat("_Blend", blend);
	}
}
