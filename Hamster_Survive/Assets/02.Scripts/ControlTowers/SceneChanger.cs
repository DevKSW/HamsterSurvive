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
        SceneManager.UnloadSceneAsync(Start);
        SceneManager.LoadSceneAsync(UI);
        SceneManager.LoadSceneAsync(InGame,LoadSceneMode.Additive);
        //Scene tInGame = SceneManager.GetSceneByBuildIndex(InGame);
        //Scene tUI = SceneManager.GetSceneByBuildIndex(UI);


        //SceneManager.SetActiveScene(tUI);

        

    }
    public static void ExitGameScene()
    {
        SceneManager.UnloadSceneAsync(UI);
        SceneManager.UnloadSceneAsync(InGame);
        SceneManager.LoadSceneAsync(Start);
        Time.timeScale = 1.0f;
    }
    public static void ExitStartScene()
    {

    }
    public static void ReloadScene()
    {
        SceneManager.UnloadSceneAsync(InGame);

        SceneManager.LoadSceneAsync(UI);
        SceneManager.LoadSceneAsync(InGame, LoadSceneMode.Additive);

        //SceneManager.SetActiveScene(SceneManager.GetSceneAt(InGame));
        Time.timeScale = 1.0f;
    }
    public static void ExitGame()
    {
        Application.Quit();
    }

}
