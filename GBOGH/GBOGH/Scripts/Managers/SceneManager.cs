using System.Collections.Generic;
using GBOGH.Scripts.Interface;

namespace EX04OOP;

public static class SceneManager
{
    public static IScene CurrentScene;
    private static Dictionary<string, IScene> scenes = new Dictionary<string, IScene>();
    public static bool Exit { get; set; }
    public static bool IsLoading { get; set; }

    public static void ChangeScene(string scene)
    {
        DisableCurrentScene();
        EnableNextScene(scene);
    }

    public static void EnableNextScene(IScene scene)
    {
        CurrentScene = scene;
        CurrentScene.OnEnable();
    }

    private static void EnableNextScene(string scene)
    {
        CurrentScene = GetScene(scene);
        CurrentScene.OnEnable();

    }

    private static IScene GetScene(string scene)
    {
        return scenes[scene];
    }

    private static void DisableCurrentScene()
    { 
        IsLoading = true;
        CurrentScene?.OnDisable();
    }

    public static void AddScene(string name, IScene scene)
    {
        
        scenes.Add(name, scene);
    }

}