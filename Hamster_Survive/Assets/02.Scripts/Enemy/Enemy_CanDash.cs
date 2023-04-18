using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_CanDash:Enemy_AI_Base
{
    protected Rigidbody2D rb;

    float tDashCoolDownTimer = 0;
    float tDashTimer = 0;

    protected float mOriginSpeed = 0;
    protected float tDashCoolDownTime = 1.0f;
    protected float tDashTime = 0.2f;
    protected Vector3 LastPlayerPos = Vector3.zero;

    protected override void Awake()
    {
        base.Awake();
        ani.GetBehaviour<Melee_Attack_End>().SetAI(this);
        ani.GetBehaviour<Start_Dash>().SetAI(this);
        ani.SetFloat("Dash_Time", 1.4f * tDashTime);
    }
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    protected override void Update()
    {
        base.Update();

    }
    public override void Init()
    {
        base.Init();
        mOriginSpeed = speed;
    }
    protected override void TimerCoolDown()
    {
        base.TimerCoolDown();

        if (tDashCoolDownTimer > 0)
        {
            tDashCoolDownTimer -= Time.deltaTime;

        }
        if(tDashTimer > 0)
        {
            tDashTimer -= Time.deltaTime;
        }
        else if (HP > 0)
        {
            ani.SetTrigger("End_Dash");
            speed = mOriginSpeed;
            
        }

    }

    protected virtual void Dash(float power)
    {
        if (tDashCoolDownTimer <= 0)
        {           
            mDirIsFixed = true;
            LastPlayerPos = Player_Main.instance.GetPos();
            _mDir = Vector3.zero;
            ani.SetTrigger("Dash");
            speed = power;
        }

    }
    public void StartDash()
    {
        tDashCoolDownTimer = tDashCoolDownTime;
        _mDir = (LastPlayerPos - transform.position).normalized ;
        tDashTimer = tDashTime;        
    }

}
