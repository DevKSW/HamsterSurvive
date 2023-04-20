using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private GameObject EmptyHp;
    [SerializeField] private GameObject FullHP;

    private void Awake()
    {
        EmptyHp.SetActive(true);
        FullHP.SetActive(true) ;
    }

    public void SetHP(bool tHP)
    {
        if (FullHP != null)
        {
            FullHP.SetActive(tHP);
        }
    }

}
