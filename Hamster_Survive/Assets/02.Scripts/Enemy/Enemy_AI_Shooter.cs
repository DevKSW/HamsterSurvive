using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Shooter: Enemy_AI_Base
{
    [SerializeField] private ObjPoolTypes arrowType = ObjPoolTypes.Enemy_AI_Boss;
    

    
    protected override void Update()
    {
        base.Update();
        if (GetDistance() >= m_attackDistance)
        {
            mDir *= 0.9f;
        }
        if (HP > 0&& m_attackTimer <= 0 && GetDistance() <= m_attackDistance )
        {
            Attack();
        }
    }
    protected override void Attack()
    {
        base.Attack();
        Enemy_Movement.Shoot(arrowType,mDir,transform.position);
        

    }
    public override void Init()
    {
        //base.Init();

        id = ObjPoolTypes.Enemy_AI_Shooter;
        m_attackDistance = 10.0f;
        m_attackCoolDown = 0.5f;
        HP = MaxHP;
        AP = MaxAttack;

        mDirIsFixed = false;
    }

    

}
