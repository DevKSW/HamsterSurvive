using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField] float Distance = 10.0f;

    public static Enemy_Spawner Instance;

    List<ObjPoolTypes> RandomTable = new List<ObjPoolTypes>();

    [SerializeField] private float SpawnCoolDown = 2;
    private float spawnTimer = 0;


    float tHrizontalRange = 19.5f;
    float tVerticalRange = 11.0f;


    private void Awake()
    {
        Init();
        Instance = this;
    }

    private void Update()
    {
        if(spawnTimer >= 0)
        {
            spawnTimer -= 1 * Time.deltaTime;
        }
        else
        {
            spawnTimer = SpawnCoolDown;
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

    public void SpawnBoss()
    {
        BossUIs.instance.PlayBossCome();
    }

    public void _SpawnBoss()
    {
        if (!Enemy_DB.instance.BossSpawned())
        {
            Vector2 pos = GetSpawnPos();
            GameObject tEnemy = Enemy_DB.instance.GetObj(ObjPoolTypes.Enemy_AI_Boss);
            tEnemy.transform.position = pos;
        }
    }
    public ObjPoolTypes GetEnemyEnum(int index)
    {
        return RandomTable[index];
    }


}
