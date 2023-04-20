using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Boss : Enemy_CanDash
{
    private float laserBeamTimer = 0;
    private float laserBeamDelay = 1.0f;

    private float laseBeamDistance = 10.0f;
    [SerializeField] private LineRenderer lineRenderer;

    private bool IsStarted = false;

    protected override void Start()
    {
        base.Start();
        ani.GetBehaviour<Start_Dash>().SetAI(this);
        ani.GetBehaviour<FalseDir_Ani>().SetAI(this);
        IsStarted = true;
        HP = 20;
    }

    protected override void Update()
    {
        base.Update();
        if (m_attackTimer <= 0 && GetDistance() <= m_attackDistance)
        {
            Attack();
        }
        
        Dash(10);
        //LazerStart(Player_Main.instance.GetPos());
        

    }
    /*private void LazerStart(Vector3 tPos)
    {
        Vector3 tDir = tPos - transform.position;

        Vector3[] pos = { transform.position + (tDir * 100),transform.position };

        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.cyan;

        lineRenderer.SetPositions(pos);
        lineRenderer.enabled = true;
        
    }*/
    protected override void Attack()
    {
        base.Attack();
        Debug.Log("Tryid");
        Enemy_Movement.Shoot(ObjPoolTypes.Boss_Arrow, mDir, transform.position);
        
    }
    public override void Init()
    {
        base.Init();
        id = ObjPoolTypes.Enemy_AI_Boss;
        /*if (IsStarted)
        {
            ani.GetBehaviour<Start_Dash>().SetAI(this);
            ani.GetBehaviour<FalseDir_Ani>().SetAI(this);
        }*/
        tDashTime = 0.75f;
        tDashCoolDownTime = 5.0f;
        m_attackDistance = 10.0f;
    }

    protected override void Dead()
    {
        BossUIs.instance.ActiveBossHPBar(false);

    }
    protected override void HPChanged(int HP , int MaxHP)
    {
        BossUIs.instance.SetBossHPBar(HP,MaxHP);
    }

}
