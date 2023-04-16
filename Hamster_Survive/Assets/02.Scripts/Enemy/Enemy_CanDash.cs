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
            speed = mOriginSpeed;
        }

    }

    protected virtual void Dash(float power)
    {
        if (tDashCoolDownTimer <= 0)
        {
            ani.SetTrigger("Dash");
            tDashCoolDownTimer = tDashCoolDownTime;
            tDashTimer = tDashTime;
            speed = power;
            mDirIsFixed = true;
        }

    }


}
