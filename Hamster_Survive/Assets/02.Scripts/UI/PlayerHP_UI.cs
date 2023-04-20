using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP_UI : MonoBehaviour
{
    public static PlayerHP_UI instance;

    [SerializeField] private GameObject HP_Prefab;
    private PlayerHP[] HPList;


    public int mPrevHP = 0;


    private void Awake()
    {
        instance = this;
        HPList = GetComponentsInChildren<PlayerHP>();
        Debug.Log(HPList.Length);

    }


    public void SetHp(int tHP)
    {
        if (!(tHP > HPList.Length))
        {
            mPrevHP = tHP;
            for (int i = 0; i < tHP; i++)
            {
                HPList[i].SetHP(true);

            }

        }
    }
    public void FalseHP(int tHP)
    {
        if(mPrevHP > tHP && tHP <= HPList.Length)
        {
            int tDamge = mPrevHP - tHP;
            for (int i = 0; i < tDamge; i++)
            {
                HPList[tHP - i].SetHP(false);
            }
            mPrevHP = tHP;    
        }

    }

}
