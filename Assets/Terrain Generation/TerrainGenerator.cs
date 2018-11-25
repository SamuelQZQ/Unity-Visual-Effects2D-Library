using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

    public float noiseMultiply;
    public float height;
    const int WIDTH = 100;

    Mesh mesh;
    Vector3[] vertexes;
    int[] triangles;
    Vector2[] uv;

    void Start()
    {
        mesh = new Mesh();
        vertexes = new Vector3[(WIDTH+1)*(WIDTH + 1)];
        uv = new Vector2[(WIDTH + 1) * (WIDTH + 1)];
        triangles = new int[3*2*WIDTH*WIDTH];

        // set vertexes
        {
            int index = 0;
            for (int i = 0; i <= WIDTH; ++i)
            {
                for (int j = 0; j <= WIDTH; ++j)
                {
                    vertexes[index] = new Vector3(i, Mathf.PerlinNoise(noiseMultiply * i / WIDTH, noiseMultiply * j / WIDTH) * height, j);
                    uv[index] = new Vector2(1.0f * i / WIDTH, 1.0f * j / WIDTH);
                    index += 1;
                }
            }    
        }

        // set triangles
        {
            int index = 0;
            int leftDown = 0;
            for (int i = 0; i < WIDTH; ++i)
            {
                for (int j = 0; j < WIDTH; ++j)
                {
                    triangles[index + 0] = leftDown;
                    triangles[index + 1] = leftDown + WIDTH + 2;
                    triangles[index + 2] = leftDown + WIDTH + 1;
                    triangles[index + 3] = leftDown;
                    triangles[index + 4] = leftDown + 1;
                    triangles[index + 5] = leftDown + WIDTH + 2;

                    index += 6;
                    leftDown += 1;
                }
                leftDown += 1;
            }
        }

        mesh.vertices = vertexes;
        mesh.triangles = triangles;
        mesh.uv = uv;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
