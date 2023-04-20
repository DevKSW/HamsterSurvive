using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] Text BestScore;
    [SerializeField] Text Score;

    [SerializeField] GameObject Best;
    [SerializeField] GameObject Good;

    public static ScoreBoard instance;

    private void Awake()
    {
        instance = this;
        this.gameObject.SetActive(false);
    }

    private string SetScore(int minit, int sec)
    {

        string tScore = minit+ "Ка "+ sec.ToString() +"УЪ";

        if (sec < 10)
        {
            tScore = tScore.Insert(tScore.Length - 2, "0");
        }
        if (minit < 10)
        {
            tScore = tScore.Insert(0,"0"); 
        }
        return tScore;
    }
    public void ActiveScoreBoard()
    {
        this.gameObject.SetActive(true);

        int minit =  ScoreManager.instance.GetMinit();
        int sec = ScoreManager.instance.GetSec();
        
        Score.text=  SetScore(minit, sec);

        int bestMinit =  DataManager.instance.m_UserData.m_BestScore_Minit;
        int bestSec = DataManager.instance.m_UserData.m_BestScore_Sec;

        int tNowScore = (minit * 100) + sec;
        int tBestScore = (bestMinit * 100) + bestSec;
        
        if(tNowScore >= tBestScore)
        {
            DataManager.instance.m_UserData.m_BestScore_Minit = minit;
            DataManager.instance.m_UserData.m_BestScore_Sec = sec;
            Best.SetActive(true);

        }
        else
        {
            Good.SetActive(true);
        }
        bestMinit = DataManager.instance.m_UserData.m_BestScore_Minit;
        bestSec = DataManager.instance.m_UserData.m_BestScore_Sec;

        BestScore.text = SetScore(bestMinit, bestSec);
        


    }

}
