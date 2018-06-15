using UnityEngine;
using UnityEngine.UI;

public class LoopBackground : MonoBehaviour {

    private Image image;
    private Material mtl;
    float distance;

    void Start () {
        image = GetComponent<Image>();
        mtl = image.material;
    }
    
    // Update is called once per frame
    void Update () {
        distance += 0.005f;
        mtl.SetFloat("_Distance", distance);
    }
}