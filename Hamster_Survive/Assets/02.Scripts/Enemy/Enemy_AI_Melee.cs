using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Melee : Enemy_AI_Base
{
    float mMotionTime = 0.5f;
    float mMotionTimer = 0.0f;
    [SerializeField] Punch mPunch = null;

    
    protected override void Update()
    {
        base.Update();
        if (mMotionTimer <= 0)
        {
            mMotionTimer = mMotionTime;
            //Enemy_Movement.AreaAttack(0, m_attackDistance - 1.0f, transform.position);
        }
        if (m_attackTimer <= 0 && GetDistance() <= m_attackDistance)
        {
            Attack();
        }
    }
    protected override void Attack()
    {
        base.Attack();
        
        
        if(mMotionTimer > 0)
        {            
            mDir = Vector3.zero;
            mDirIsFixed = true;

            Vector3 tDir = GetDir();
            mPunch.Attack(tDir);
        }
        
    }
    

    public override void Init()
    {
        base.Init();
        id = ObjPoolTypes.Enemy_AI_Melee;
        //m_attackDistance = 1.9f;
        //m_attackCoolDown = 1.0f;
        mMotionTime = 1.0f;
        mMotionTimer = mMotionTime;
        //speed = 2.0f;
        

    }
    protected override void TimerCoolDown()
    {
        base.TimerCoolDown();
        if(mMotionTimer > 0)
        {
            mMotionTimer -=Time.deltaTime;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        mPunch = GetComponentInChildren<Punch>();
    }
    private void Start()
    {
        ani.GetBehaviour<FalseDir_Ani>().SetAI(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, m_attackDistance);
    }

    

}
