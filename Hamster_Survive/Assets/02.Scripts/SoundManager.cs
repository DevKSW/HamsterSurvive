using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] AudioSource BGM;


    [SerializeField] AudioSource playerAttack;
    [SerializeField] AudioSource playerHit;
    [SerializeField] AudioSource Result;
    [SerializeField] AudioSource BossCome;

    [SerializeField] List<AudioSource> EffectSounds;

    private void OnEnable()
    {
        BGM.enabled = true;
        foreach (var sound in EffectSounds)
        {
            sound.enabled = true;
        }

    }
    private void OnDisable()
    {
        BGM.enabled = false;
        foreach (var sound in EffectSounds)
        {
            sound.enabled = false;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        //DontDestroyOnLoad(this);
    }
    private void Start()
    {
        EffectSounds.Add(playerAttack);
        EffectSounds.Add(playerHit);
        EffectSounds.Add(Result);
        EffectSounds.Add(BossCome);

    }

    public void BgmSettingChanged(Slider tSlider)
    {
        if (DataManager.instance != null)
        {
            DataManager.instance.m_UserData.m_BgmSetting = tSlider.value;
            DataManager.instance.SaveData();
            BGM.volume = DataManager.instance.m_UserData.m_BgmSetting;
        }
    }
    public void EffectSoundSettingChanged(Slider tSlider)
    {
        if (DataManager.instance != null)
        {
            DataManager.instance.m_UserData.m_EffectSoundSetting = tSlider.value;
            DataManager.instance.SaveData();
            foreach (var sound in EffectSounds)
            {
                sound.volume = DataManager.instance.m_UserData.m_EffectSoundSetting;
            }
        }

    }

    public void InitBGMSettingBar(Slider tBGMSlider)
    {
        if (DataManager.instance != null) {
            if(tBGMSlider != null)
            {
                tBGMSlider.value = DataManager.instance.m_UserData.m_BgmSetting;
            }
        }
    }
    public void InitEffectSettingBar(Slider tEffectSlider)
    {
        if (DataManager.instance != null)
        {
            if (tEffectSlider != null)
            {
                tEffectSlider.value = DataManager.instance.m_UserData.m_EffectSoundSetting;
            }
        }
    }
    public void PlayerAttack()
    {
        playerAttack.Play();
    }
    public void PlayResult()
    {
        BGM.Stop();    
        Result.Play();
    }
    public void PlayBossCome()
    {
        BossCome.Play();
    }
    public void PlayerHit()
    {
        playerHit.Play();
    }
}
