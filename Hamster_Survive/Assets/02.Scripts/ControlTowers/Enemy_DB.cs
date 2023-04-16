using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DB : MonoBehaviour
{
    private static Enemy_DB _instance = null;
    public static Enemy_DB instance
    {
        get { return _instance; }
        set { }
    }

    [SerializeField] private GameObject enemy_Base;
    [SerializeField] private GameObject enemy_Melee;
    [SerializeField] private GameObject enemy_Shooter;
    [SerializeField] private GameObject enemy_Boss;
    [SerializeField] private GameObject Arrow_Base;
    [SerializeField] private GameObject Player_Projectiles;
    [SerializeField] private GameObject Boss_Arrow;

    [SerializeField] private GameObject OP;

    private Dictionary<ObjPoolTypes,List<GameObject>> _enemyList = new Dictionary<ObjPoolTypes, List<GameObject>>();
    private Dictionary<ObjPoolTypes, Transform> OPs = new Dictionary<ObjPoolTypes, Transform>();


    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        for (ObjPoolTypes i = ObjPoolTypes.None; i < ObjPoolTypes.End; i++)
        {
            GameObject tOP = Instantiate<GameObject>(OP, this.transform);
            tOP.name = tOP.name.Insert(tOP.name.Length,i.ToString());
            OPs.Add(i, tOP.transform);
        }

        InitOP(enemy_Base,200);
        InitOP(Arrow_Base,500);
        InitOP(enemy_Shooter, 100);
        InitOP(enemy_Melee, 100);
        InitOP(enemy_Boss, 100);
        InitOP(Player_Projectiles, 100);
        InitOP(Boss_Arrow, 100);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitOP(GameObject tOrigin , int length = 1000 )
    {
        tOrigin.GetComponent<CanOP>().Init();
        ObjPoolTypes tID = tOrigin.GetComponent<CanOP>().GetOPID();
        


        if( !_enemyList.ContainsKey(tID))
        {
            List<GameObject> tList = new List<GameObject>();

            for (int i = 0; i < length; i++)
            {
                GameObject tObj = Instantiate(tOrigin,OPs[tID]);
                //tObj.GetComponent<CanOP>().Init();
                tObj.name = tOrigin.name + i;
                tObj.SetActive(false);
                tList.Add(tObj);
            }
            
            _enemyList.Add(tID,tList);
        }

    }

    public GameObject GetObj(ObjPoolTypes tID)
    {
 
        if( _enemyList.ContainsKey(tID))
        {
            GameObject tObj = _enemyList[tID][_enemyList[tID].Count-1];
            _enemyList[tID].RemoveAt(_enemyList[tID].Count - 1);

            tObj.transform.parent = null;
            tObj.SetActive(true);

            return tObj;

        }

        return null;
    }
    public void ReturnObj(GameObject tObj)
    {
        ObjPoolTypes tID = tObj.GetComponent<CanOP>().GetOPID();
        if (_enemyList.ContainsKey(tID))
        {
            _enemyList[tID].Add(tObj);
            tObj.SetActive(false);
            tObj.GetComponent<CanOP>().Init();
            tObj.transform.parent = OPs[tID];
        }
    }

    /*public Vector3 GetDir(Vector3 EnemyPos)
    {
        Vector3 dir = Vector3.zero;
        dir = Player_Main.instance.GetPos() - EnemyPos;
        return dir.normalized;
    }*/
    

}
