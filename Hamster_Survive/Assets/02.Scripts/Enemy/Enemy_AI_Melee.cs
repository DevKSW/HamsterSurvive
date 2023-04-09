using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Melee : Enemy_AI_Base
{
    float mMotionTime = 0.5f;
    float mMotionTimer = 0.0f;
    [SerializeField] private Transform attackRange;

    protected override void Update()
    {
        base.Update();
        if (mMotionTimer <= 0)
        {
            mMotionTimer = mMotionTime;
            attackRange.GetComponent<SpriteRenderer>().enabled = false;
            mDirIsFixed = false;
            Enemy_Movement.AreaAttack(0, m_attackDistance - 1.0f, transform.position);
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
            attackRange.localScale = Vector3.one * m_attackDistance * 2;
            attackRange.GetComponent<SpriteRenderer>().enabled = true;
            mDir = Vector3.zero;
            mDirIsFixed = true;
        }
        
    }
    

    public override void Init()
    {
        base.Init();
        id = ObjPoolTypes.Enemy_AI_Melee;
        m_attackDistance = 3.0f;
        m_attackCoolDown = 0.1f;
        mMotionTime = 1.0f;
        mMotionTimer = mMotionTime;
        speed = 2.0f;
        

    }
    protected override void TimerCoolDown()
    {
        base.TimerCoolDown();
        if(mMotionTimer > 0)
        {
            mMotionTimer -=Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, m_attackDistance-1.0f);
    }


}
