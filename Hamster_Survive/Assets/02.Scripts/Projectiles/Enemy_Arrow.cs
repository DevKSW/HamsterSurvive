using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Arrow : CanOP
{
    private float _speed = 4.0f;
    private float timer  = 5.0f;

    [SerializeField] private ObjPoolTypes ID = ObjPoolTypes.Enemy_Arrow;

    public float speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    private Vector3 dir = Vector3.zero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player Hit ! (Arrow) ");
    }

    private void FixedUpdate()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
    private void Update()
    {
        if(timer > 0)
        {
            timer-= Time.deltaTime;
        }
        else
        {
            Enemy_DB.instance.ReturnObj(this.gameObject);
        }
    }
    public void Shoot(Vector3 tDir)
    {
        float angle = Mathf.Atan2(tDir.y, tDir.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle  - 90.0f , Vector3.forward);
        transform.rotation = angleAxis;
        dir = tDir.normalized;
    }
    
    public override void Init()
    {
        id = ID;
        dir = Vector3.zero;
        timer = 5.0f;
    }

}
