using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResolution : MonoBehaviour
{
    private int witdh = 1920;
    private int height = 1080;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(witdh, height, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
