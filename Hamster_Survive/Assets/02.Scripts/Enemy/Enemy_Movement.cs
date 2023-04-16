using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement
{ 
    public static void Shoot(ObjPoolTypes tType , Vector3 tDir , Vector3 tPos)
    {
        if (tDir != Vector3.zero)
        {
            GameObject tArrow = Enemy_DB.instance.GetObj(tType);
            if (tArrow != null)
            {
                Enemy_Arrow arrow;
                if (tArrow.TryGetComponent<Enemy_Arrow>(out arrow))
                {
                    arrow.transform.position = tPos;
                    arrow.Shoot(tDir);
                }
            }
        }
    }
    public static void AreaAttack(int damage, float range, Vector3 tPos)
    {
        LayerMask playerLayer = Player_Main.instance.GetPlayerLayer();

        Collider2D player = Physics2D.OverlapCircle(tPos, range, playerLayer.value>>1);

        if(player != null)
        {
            Debug.Log("Hit! (MeleeAttack)");
            
        }
        else
        {
            Debug.Log("Didnt Hit!");
        }
        return;
    }
    


}
