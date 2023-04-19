using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    Animator ani;
    Collider2D col;
    public int AP = 1;


    private void Awake()
    {
        ani = GetComponentInChildren<Animator>();
        col = GetComponent<Collider2D>();
    }

    private void Start()
    {
        ani.GetBehaviour<Melee_Attack>().SetPunch(this);
    }
    public void Attack(Vector3 tDir)
    {
        float angle = Mathf.Atan2(tDir.y, tDir.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 180.0f, Vector3.forward);
        transform.rotation = angleAxis;

        ani.SetTrigger("Attack");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Player_Main.instance.Hit(AP))
        {
            Debug.Log("Hit(Melee)");
        }

    }


    public void ActiveCol()
    {
        if (col.enabled == false)
        {
            col.enabled = true;
        }
    }
    public void DisableCol()
    {
        if(col.enabled == true)
        {
            col.enabled = false;
        }
    }

}
