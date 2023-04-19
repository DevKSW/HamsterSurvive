using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField] float Distance = 10.0f;

    List<ObjPoolTypes> RandomTable = new List<ObjPoolTypes>();

    [SerializeField] private float SpawnTime = 1;
    private float spawnTimer = 0;


    float tHrizontalRange = 19.5f;
    float tVerticalRange = 11.0f;


    private void Awake()
    {
        Init();
        
    }

    private void Update()
    {
        if(spawnTimer >= 0)
        {
            spawnTimer -= 1 * Time.deltaTime;
        }
        else
        {
            spawnTimer = SpawnTime;
            Spawn();
        }

    }

    private void Init()
    {
        for (int i = 0; i < 100; i++)
        {
            RandomTable.Add(ObjPoolTypes.None);
        }


        RandomTable[0] = ObjPoolTypes.Enemy_AI_Base + Random.Range(0, 2); 


        for (ObjPoolTypes i = ObjPoolTypes.Enemy_AI_Base; i < ObjPoolTypes.Enemy_AI_Boss; i++)
        {
            int tCount = 0;
            while (tCount < 33)
            {
                int tIndex = Random.Range(0,100);
                if(RandomTable[tIndex] == ObjPoolTypes.None)
                {
                    tCount++;
                    RandomTable[tIndex] = i;
                }

            }

        }
    }

    public void Spawn()
    {
        int tIndex = Random.Range(0, 100);
        if(RandomTable[tIndex] != ObjPoolTypes.None)
        {
            //Debug.Log(RandomTable[tIndex].ToString());
            Vector2 pos = GetSpawnPos();
            GameObject tEnemy = Enemy_DB.instance.GetObj(RandomTable[tIndex]);
            tEnemy.transform.position = pos;
        }

    }

    private Vector2 GetSpawnPos()
    {
        Vector2 tSpawnPos = Vector2.zero;
        bool CantSpawn = true;
        while (CantSpawn)
        {
            float tX = Random.Range(-tHrizontalRange, tHrizontalRange);
            float tY = Random.Range(-tVerticalRange, tVerticalRange);
            tSpawnPos = new Vector2(tX, tY);
            Vector2 tPlayerPos = Player_Main.instance.GetPos();
            float tDistance = (tPlayerPos - tSpawnPos).magnitude;

            if (tDistance >= Distance)
            {
                CantSpawn = false;
            }
        }
        return tSpawnPos;
    }


    public ObjPoolTypes GetEnemyEnum(int index)
    {
        return RandomTable[index];
    }


}
