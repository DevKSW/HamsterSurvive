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
    [Header("�÷��̾� ���� �������ͽ�")]
    public double AttackRate = 0.3;
    public float AttackRadius = 10.0f;
    [SerializeField] private Transform firePoint;


    [Header("�÷��̾� ���� �ð�")]
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
        AP = 1;
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
        else if (Input.GetMouseButton(0))
        {
            Vector3 tMousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 tDir = tMousePos - transform.position;
            tDir.z = 0;
            AttackTimer = AttackRate;
            Attack(tDir.normalized);
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


    private void Attack(Vector3 tDir)
    {
        //tDir -= firePoint.position;
        GameObject tArrow = Enemy_DB.instance.GetObj(ObjPoolTypes.Player_Projectiles);
        tArrow.transform.position = firePoint.position;
        ani.SetTrigger("Attack");
        tArrow.GetComponent<Player_Projectiles>().Shoot(tDir,AP);
        
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        ScoreManager.instance.Stop = true;
        playerMove.enabled = false;
        this.enabled = false;


    }

}
