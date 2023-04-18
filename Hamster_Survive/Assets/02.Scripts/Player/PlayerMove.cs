using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Transform tr;
    public float speed = 10;
    private Vector2 move = Vector2.zero;

    //private KeyCode up_K = KeyCode.UpArrow;
    //private KeyCode down_K = KeyCode.DownArrow;
    //private KeyCode right_K = KeyCode.RightArrow;
    //private KeyCode left_K = KeyCode.LeftArrow;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        tr.position += (Vector3)move * speed *Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        if (tr.position.y >= 11 || tr.position.y <= -10.7)
        {
            float y = tr.position.y > 0 ? 10.98f : -10.68f;
            tr.position = new Vector3(tr.position.x, y);
            vertical = 0 ;
        }
        if (tr.position.x >= 19.5 || tr.position.x <= -19.5)
        {
            float x = tr.position.x > 0 ? 19.48f : -19.48f;
            tr.position = new Vector3(x, tr.position.y);
            horizontal = 0;

        }

        move = new Vector2(horizontal, vertical);

        if (horizontal > 0)
        {
            Player_Main.instance.render.flipX = true;
        }
        else if (horizontal < 0)
        {
            Player_Main.instance.render.flipX = false;
        }


        if (move.magnitude > 0.0)
        {
            Player_Main.instance.ani.SetBool("IsMove",true);
        }
        else
        {
            Player_Main.instance.ani.SetBool("IsMove", false);
        }

    }

    

}
