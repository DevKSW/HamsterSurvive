using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public int m_BestScore_Minit =0;
    public int m_BestScore_Sec =0;

    public float m_BgmSetting =1;
    public float m_EffectSoundSetting =1;

}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private string path;
    private string fileName = "Datas";

    public UserData m_UserData = new UserData();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(instance.gameObject);
        }
        //DontDestroyOnLoad(gameObject);

        path = Application.persistentDataPath + "/";

    }
    private void OnEnable()
    {
        LoadData();
    }

    private void Start()
    {
    }

    private void OnDisable()
    {
        SaveData();
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(m_UserData);
        File.WriteAllText(path+fileName, data);
    }
    public void LoadData()
    {
        if (!File.Exists(path + fileName))
        {
            SaveData();
        }
        string data = File.ReadAllText(path+fileName);
        m_UserData = JsonUtility.FromJson<UserData>(data);
    }


    //public 
    

}
