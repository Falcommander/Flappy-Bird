using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ScenesManager
{
    public static string scene1 = "scene1-Initialisation";
    public static string scene2 = "scene2-Menu";
    public static string scene3 = "scene3-Game";
    public static string scene4 = "scene4-GameOver";

    public static void LoadScene1()
    {
        SceneManager.LoadSceneAsync(scene1);
    }

    public static void LoadScene2()
    {
        SceneManager.LoadSceneAsync(scene2);
    }

    public static void LoadScene3()
    {
        SceneManager.LoadSceneAsync(scene3);
    }

    public static void LoadScene4()
    {
        SceneManager.LoadScene(scene4);
    }
}
