using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeBall : MonoBehaviour
{
    private int size;
    
    // Start is called before the first frame update
    void Start()
    {
        size = 1;
        transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    public void ChangeSize()
    {
        if (size == 1)
        {
            size = 2;
            transform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            size = 1;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
