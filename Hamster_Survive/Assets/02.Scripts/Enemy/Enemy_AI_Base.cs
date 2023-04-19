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

    
    protected float m_attackTimer = 0f;

    protected int AP = 1;
    private int _HP;
    public int HP
    {
        get { return _HP; }
        set {
            if (value >= _HP)
            {
                _HP = value;
            }
            else if (value <= 0)
            {
                mDirIsFixed = true;
                _mDir = Vector3.zero;
                ani.GetBehaviour<Enemy_Destroy>().SetAI(this);
                ani.SetTrigger("Dead");

            }
            else
            {
                _HP = value;
                ani.SetTrigger("Hit");
            }
        }

    }


    [Header("Àû ±âº» ½ºÆå")]
    [SerializeField] private int MaxHP = 0;
    [SerializeField] private int MaxAttack = 0;
    [SerializeField] protected float m_attackDistance = 0.0f;
    [SerializeField] protected float m_attackCoolDown = 0.5f;

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
        TimerCoolDown();
        mDir = GetDir();
        if(mDir.x < 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 1);
        }else if(mDir.x > 0)
        {
            transform.rotation = new Quaternion(0,180,0,1);
        }
        
        
        

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

        HP = MaxHP;
        AP = MaxHP;

        mDirIsFixed = false;

    }
    
    protected virtual void Attack()
    {
        m_attackTimer = m_attackCoolDown;
        ani.SetTrigger("Attack");
    }
    protected virtual void TimerCoolDown()
    {
        if (m_attackTimer > 0)
        {
            m_attackTimer -= Time.deltaTime;
        }
        

    }
    public void Return()
    {
        this.gameObject.SetActive(false);
        Enemy_DB.instance.ReturnObj(gameObject);
    }
    public void FalseDirFixed()
    {
        mDirIsFixed = false;
    }

    public void Stop()
    {
        mDirIsFixed = true;
        _mDir = Vector3.zero;
    }

}
