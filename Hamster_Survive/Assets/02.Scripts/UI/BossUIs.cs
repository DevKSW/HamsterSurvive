using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUIs : MonoBehaviour
{
    public static BossUIs instance;

    [SerializeField] private GameObject BossBar;
    [SerializeField] private GameObject BossComming;
    private Slider BossSlider;

    private float Timer = 0;

    [SerializeField] private float BossWarnnigTime = 1;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
            BossSlider = BossBar.GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (BossComming.active)
        {
            if (Timer >= 0)
            {
                Timer = Timer - (1 * Time.deltaTime);
            }
            else
            {
                BossComming.SetActive(false);
                Enemy_Spawner.Instance._SpawnBoss();
                ActiveBossHPBar(true);
            }
        }

    }



    public void PlayBossCome()
    {
        Timer = BossWarnnigTime;
        BossComming.SetActive(true);

    }

    public void ActiveBossHPBar(bool isAlive)
    {
        BossBar.SetActive(isAlive);
    }
    public void SetBossHPBar(int HP,int MaxHP)
    {
        BossSlider.value = (float)HP / (float)MaxHP;
    }

}
