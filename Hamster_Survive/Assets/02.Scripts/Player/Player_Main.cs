using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Main : MonoBehaviour
{
    public static Player_Main instance;
    [SerializeField] private PlayerMove playerMove;
    
    private Info playerInfo = new Info(1,10,1);

    private int _HP;
    private int _AP;



    private int HP
    {
        get { return _HP; }
        set {
            if(value > _HP)
            {
                _HP = value;
            }
            else if (CanBeatable)
            {
                CanBeatable = false;
                Debug.Log(_HP);

                switch (value)
                {
                    case <= 0:
                        ani.SetTrigger("Dead");
                        break;
                    default:
                        ani.SetTrigger("Hit");
                        _HP = value;
                        break;
                }

            }
        }
    } 
    private int AP
    {
        get { return _AP; }
        set { _AP = value; }
    }
    private float speed
    {
        get {return playerMove.speed; }
        set {playerMove.speed = value;}
    }
    

    private double AttackTimer = 0;
    [Header("플레이어 공격 스테이터스")]
    public double AttackRate = 0.3;
    public float AttackRadius = 10.0f;
    [SerializeField] private Transform firePoint;


    [Header("플레이어 무적 시간")]
    public bool CanBeatable = true;

    [Header("Renderer")]
    public SpriteRenderer render;
    public Animator ani;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        playerMove = GetComponent<PlayerMove>();
        ani = GetComponentInChildren<Animator>();
        _HP = playerInfo.MaxHP;
        _AP = playerInfo.MaxAttackPoint;
        AP = 0;
    }

    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(AttackTimer > 0)
        {
            AttackTimer -= Time.deltaTime;
            //Debug.Log(UnbeatableTimer); 
        }
        else
        {
            AttackTimer = AttackRate;
            Attack();
        }

    }

    public Vector3 GetPos()
    {
        return transform.position;
    }
    public LayerMask GetPlayerLayer()
    {
        return gameObject.layer;
    }

    public bool Hit(int damage = 1)
    {
        int prevHP = HP;
        HP -= damage;
        if(prevHP == HP)
        {
            return false;
        }
        return true;
    }
    private void Attack()
    {
        Collider2D[] Enemys = Physics2D.OverlapCircleAll(transform.position,AttackRadius);

        if (Enemys != null)
        {
            foreach (Collider2D enemy in Enemys)
            {
                Enemy_AI_Base enemy_AI;
                if (enemy.TryGetComponent<Enemy_AI_Base>(out enemy_AI))
                {
                    Vector3 tDir = enemy.transform.position + (Vector3.down * 0.3f) - firePoint.position;
                    GameObject tArrow = Enemy_DB.instance.GetObj(ObjPoolTypes.Player_Projectiles);
                    tArrow.transform.position = firePoint.position;
                    ani.SetTrigger("Attack");
                    tArrow.GetComponent<Player_Projectiles>().Shoot(tDir,AP);
                    break;
                }
            }
        }

    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
    }

}
