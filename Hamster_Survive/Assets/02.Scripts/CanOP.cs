using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanOP : MonoBehaviour
{
    protected ObjPoolTypes id = ObjPoolTypes.None;
    protected CanOP()
    {
        Init();
    }

    protected virtual void Awake()
    {
        Init();
    }

    public ObjPoolTypes GetOPID()
    {
        return id;
    }
    public virtual void Init()
    {

    }
}
