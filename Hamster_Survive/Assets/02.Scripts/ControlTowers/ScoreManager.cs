using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    float Second = 0;
    int Minit = 0;

    [SerializeField] private int BossSpawnCoolDown = 20;

    [SerializeField] private Text mScoreBoard;
    public bool Stop = false;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Second = 0;
        Minit = 0;
    }

    private void FixedUpdate()
    {
        Second += 1 * Time.fixedDeltaTime;    
    }
    
    void Update()
    {
        if (!Stop)
        {
            CalcTime();
            SetText();
        }
    }

    private void CalcTime()
    {

        if (Second / 60 >= 1)
        {
            Second = 0.0f;
            Minit++;
        }
    }

    private void SetText()
    {
        int tSecond = ((int)Second);

        string tText = Minit.ToString() + "  :  " +  tSecond.ToString();
        
        if (tSecond < 10)
        {
            tText = tText.Insert(tText.Length-1,"0");
        }
        if (Minit < 10)
        {
            tText = tText.Insert(0,"0");
        }

        if(tSecond != 0 && tSecond % BossSpawnCoolDown == 0)
        {
            Enemy_Spawner.Instance.SpawnBoss();
        }

        mScoreBoard.text = tText;
    }

}
