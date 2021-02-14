using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleBallColor : MonoBehaviour
{
    public Material[] colors;
    Renderer rend;
    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = colors[0];
    }

    public void changeColor(int newColor)
    {
        rend.sharedMaterial = colors[newColor];
    }
}
