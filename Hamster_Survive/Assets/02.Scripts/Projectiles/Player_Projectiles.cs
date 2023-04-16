using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Projectiles: CanOP
{
    [SerializeField] protected float _speed = 3;

    private int damage;

    private float timer = 10.0f;


    public float speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    private Vector3 dir = Vector3.zero;

    private void FixedUpdate()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Enemy_DB.instance.ReturnObj(this.gameObject);
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy_AI_Base tEnemy;
        if(collision.transform.TryGetComponent<Enemy_AI_Base>(out tEnemy))
        {
            tEnemy.HP -= damage;
        }
        Enemy_DB.instance.ReturnObj(this.gameObject);
    }

    public void Shoot(Vector3 tDir, int tDamage = 1)
    {
        float angle = Mathf.Atan2(tDir.y, tDir.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90.0f, Vector3.forward);
        transform.rotation = angleAxis;
        dir = tDir.normalized;
        damage = tDamage;
    }

    public override void Init()
    {
        id = ObjPoolTypes.Player_Projectiles;
        dir = Vector3.zero;
        timer = 5.0f;
    }
}
