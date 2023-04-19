using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP_UI : MonoBehaviour
{
    public static PlayerHP_UI instance;

    [SerializeField] private GameObject HP_Prefab;
    private PlayerHP[] HPList;


    private int mPrevHP = 0;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        PlayerHP[] HPList = GetComponentsInChildren<PlayerHP>();
        Debug.Log(HPList.Length);

    }


    //public void InitHp(int tHP)
    //{
    //    if(tHP > 5)
    //    {
    //        float tLength =  (tHP - 5)/10;
    //        this.GetComponent<RectTransform>().localScale = new Vector3(tLength,tLength);
    //    }
    //
    //    for (int i = 0; i < tHP; i++)
    //    {
    //        GameObject tHPUI = Instantiate(HP_Prefab,GetComponent<RectTransform>());
    //        HPList.Add(tHPUI.GetComponent<PlayerHP>());
    //        tHPUI.SetActive(true);
    //    }
    //}
    public void SetHP(int tHP)
    {
        if(mPrevHP > tHP)
        {
             HPList[tHP - 1].SetHP(false);
             mPrevHP = tHP;    
        }

    }

}
