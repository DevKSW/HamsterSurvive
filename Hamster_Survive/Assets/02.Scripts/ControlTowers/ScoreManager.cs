using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    float Second = 0;
    int Minit = 0;

    [SerializeField] private Text mScoreBoard;

    void Start()
    {
        Second = 0;
        Minit = 0;
    }

    private void FixedUpdate()
    {
        Second += 1 * Time.fixedDeltaTime;    
    }
    // Update is called once per frame
    void Update()
    {
        if(Second/60 >= 1)
        {
            Second = 0.0f;
            Minit ++;  
        }
        int tSecond = ((int)Second);

        string tText = Minit.ToString() + "  :  "+ tSecond.ToString();

        mScoreBoard.text = tText;


    }


}
