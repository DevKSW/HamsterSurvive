using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Enemy_AI_Base : CanOP
{
    [SerializeField] protected float speed = 3;

    protected Animator ani;


    protected Vector3 _mDir = Vector3.zero;

    protected bool mDirIsFixed = false;
    protected Vector3 mDir
    {
        get { return _mDir; }
        set
        {
            if (!mDirIsFixed)
            {
                _mDir = value;
                if (_mDir.magnitude > 0)
                {
                    ani.SetBool("Move",true);
                }
                else
                {
                    ani.SetBool("Move", false);
                }
            }
            

        }
    }

    protected float m_attackCoolDown = 0.5f;
    protected float m_attackTimer = 0f;

    private int AP = 1;
    private int _HP;
    private int HP
    {
        get { return _HP; }
        set { 
            if (value <= 0)
            {
                ani.SetTrigger("DEAD");
            }else if (value >= _HP)
            {
                _HP = value;
            }
            else
            {
                _HP = value;
                ani.SetTrigger("Hit");
            }
        }

    }

    protected float m_attackDistance = 0.0f;


    protected override void Awake()
    {
        Init();
        ani = GetComponentInChildren<Animator>();
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }
    protected virtual void Update()
    {
        mDir = GetDir();
        
        TimerCoolDown();
        
        

    }

    
        
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (Player_Main.instance.Hit(1))
        {
            Debug.Log("Hit(Base)");
        }
        
    }
    protected Vector3 GetDir()
    {
        Vector3 dir = Vector3.zero;
        dir = Player_Main.instance.GetPos() - transform.position;   
        return dir.normalized;
    }

    protected float GetDistance()
    {
        Vector3 tV_Distance =  Player_Main.instance.GetPos() - transform.position;
        return tV_Distance.magnitude;
    }

    private void Move()
    {
        transform.position += mDir * speed* Time.fixedDeltaTime;
    }
    public override void Init()
    {
        m_attackTimer = m_attackCoolDown;

        id = ObjPoolTypes.Enemy_AI_Base;
    }
    
    protected virtual void Attack()
    {
        m_attackTimer = m_attackCoolDown;
    }
    protected virtual void TimerCoolDown()
    {
        if (m_attackTimer > 0)
        {
            m_attackTimer -= Time.deltaTime;
        }
        

    }

}
