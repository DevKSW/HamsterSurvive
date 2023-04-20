using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjPoolTypes
{
    None,
    Enemy_AI_Base,
    Enemy_AI_Shooter,
    Enemy_AI_Melee,
    Enemy_AI_Boss,
    Enemy_Arrow,
    Boss_Arrow,
    Player_Projectiles,
    End
    
}

[SerializeField]
public class Info{
    [SerializeField] public int MaxAttackPoint;
    [SerializeField] public int MaxHP;
    [SerializeField] public int MaxSpeed;

    public Info(int tAP =1 , int tHP = 5 , int tSpeed = 1)
    {
        MaxAttackPoint = tAP;
        MaxHP = tHP;
        MaxSpeed = tSpeed;
        
    }


}

public class PlayerInfo : Info
{

    public PlayerInfo()
    {

    }


}

