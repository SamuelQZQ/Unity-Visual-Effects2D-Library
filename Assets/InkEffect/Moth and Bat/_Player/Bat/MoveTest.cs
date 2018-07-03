using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = transform.position;
        position.x += Time.deltaTime*6;
        position.y += Time.deltaTime * 3;
        transform.position = position;
	}
}
