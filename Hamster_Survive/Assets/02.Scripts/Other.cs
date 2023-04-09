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
    End
    
}

public class Info{
    public int MaxAttackPoint;
    public int MaxHP;
    public int MaxSpeed;

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

