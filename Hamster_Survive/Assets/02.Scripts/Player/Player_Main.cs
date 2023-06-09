using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Main : MonoBehaviour
{
    public static Player_Main instance;
    [SerializeField] private PlayerMove playerMove;
    
    //[SerializeField] private Info playerInfo = new Info(1,10,1);
    [SerializeField] private int MaxHP = 5;
    [SerializeField] private int MaxDamage = 1;


    private int _HP;
    private int _AP;

    [SerializeField] private Transform camera;

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
                        SoundManager.instance.PlayerHit();
                        ani.SetTrigger("Dead");
                        break;
                    default:
                        ani.SetTrigger("Hit");
                        SoundManager.instance.PlayerHit();
                        _HP = value;
                        break;
                }
                PlayerHP_UI.instance.FalseHP(value);

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
        _HP = MaxHP;
        _AP = MaxDamage;
        AP = 1;
    }
    private void Start()
    {
        PlayerHP_UI.instance.SetHp(HP);
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
            SoundManager.instance.PlayerAttack();
            Attack(tDir.normalized);
        }

        //( 11.1 , 6.3)
        float tX = transform.position.x;
        float tY = transform.position.y;

        if(transform.position.x >= 11f || transform.position.x <= -11f)
        {
            tX = transform.position.x > 0 ? 10.98f : -10.98f;
            //camera.position. = 11.0f;
        }
        if(transform.position.y >= 8.3f  || transform.position.y <= -6.3f)
        {
            tY = transform.position.y > 0 ? 8.28f : -6.28f;
        }
        camera.position = new Vector3 (tX, tY , camera.position.z);


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

    public void GameOverBegin()
    {
        Debug.Log("Game Over!");
        ScoreManager.instance.Stop = true;
        playerMove.enabled = false;
        this.enabled = false;
        

    }
    public void GameOverEnd()
    {
        Time.timeScale = 0;
        SoundManager.instance.PlayResult();
        ScoreBoard.instance.ActiveScoreBoard();

    }

}
