using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneManager", menuName = "Scriptable Object/SceneManager", order = int.MaxValue)]
public class SceneChanger : ScriptableObject
{
    public static int InGame = 1;
    public static int Start = 0;
    public static int UI = 2;
    public static int Result =3;

    private static Scene mUIScene;

    public static void EnterGameScene()
    {
        SceneManager.LoadSceneAsync(InGame);
        SceneManager.UnloadSceneAsync(Start);
        SceneManager.LoadSceneAsync(UI, LoadSceneMode.Additive);
        //Scene tInGame = SceneManager.GetSceneByBuildIndex(InGame);
        //Scene tUI = SceneManager.GetSceneByBuildIndex(UI);


        //SceneManager.SetActiveScene(tUI);

        

    }
    public static void ExitGameScene()
    {
        SceneManager.UnloadSceneAsync(InGame);
        SceneManager.UnloadSceneAsync(UI);

        SceneManager.LoadSceneAsync(Start);
        Time.timeScale = 1.0f;
    }
    public static void ExitStartScene()
    {

    }
    public static void ReloadScene()
    {
        SceneManager.UnloadSceneAsync(InGame);

        SceneManager.LoadSceneAsync(InGame);
        SceneManager.LoadSceneAsync(UI, LoadSceneMode.Additive);

        SceneManager.SetActiveScene(SceneManager.GetSceneAt(InGame));
        Time.timeScale = 1.0f;
    }
    public static void ExitGame()
    {
        Application.Quit();
    }

}
