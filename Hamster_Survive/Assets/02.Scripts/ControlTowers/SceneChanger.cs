using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : ScriptableObject
{
    public static Scene InGame;
    public static Scene Start;
    public static Scene UI;
    public static Scene End;

    public static void EnterGameScene()
    {
        SceneManager.UnloadSceneAsync(Start);
        SceneManager.UnloadSceneAsync(End);
        SceneManager.LoadSceneAsync(InGame.name);
        SceneManager.LoadSceneAsync(UI.name);

    }
    public static void ExitGameScene()
    {

    }
    public static void ExitStartScene()
    {

    }

}
