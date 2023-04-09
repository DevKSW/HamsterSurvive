using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Main : MonoBehaviour
{
    public static Player_Main instance;
    [SerializeField] private PlayerMove playerMove;
    
    private Info playerInfo = new Info();

    private int _HP;
    private int _AP;


    private int HP
    {
        get { return _HP; }
        set {
            if ( value <= 0)
            {
                ani.SetTrigger("DEAD");
            }
            else
            {
                ani.SetTrigger("Hit");
                _HP = value;
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

    private float HitTimer = 0 ;
    private float HitTime = 0.3f;

    public SpriteRenderer render;

    public Animator ani;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        playerMove = GetComponent<PlayerMove>();
        ani = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HitTimer >= 0)
        {
            HitTimer -= Time.deltaTime; 
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

    public void Hit(int damage = 1)
    {
        if(HitTimer <=0)
        {
            HitTimer = HitTime;
            
        }

    }
    public void GameOver()
    {
        Debug.Log("Game Over!");
    }
}
