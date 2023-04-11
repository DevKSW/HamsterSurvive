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
            if (UnbeatableTimer <= 0)
            {
                UnbeatableTimer = UnbeatableTime;
                Debug.Log(_HP);
                if (value <= 0)
                {
                    ani.SetTrigger("Dead");
                }
                else
                {
                    ani.SetTrigger("Hit");
                    _HP = value;
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
    

    private double UnbeatableTimer = 0 ;
    [Header("플레이어 무적 시간")]
    [SerializeField]private double UnbeatableTime = 1.0f;

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
    }

    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(UnbeatableTimer > 0)
        {
            UnbeatableTimer -= Time.deltaTime;
            //Debug.Log(UnbeatableTimer); 
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
    public void GameOver()
    {
        Debug.Log("Game Over!");
    }

}
