using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private Image EmptyHp;
    [SerializeField] private Image FullHP;

    private void Awake()
    {
        EmptyHp.enabled = true;
        FullHP.enabled = true;
    }

    public void SetHP(bool tHP)
    {
        if (tHP)
        {
            FullHP.enabled = true;
        }
        else
        {
            FullHP.enabled = false;
        }

    }

}
