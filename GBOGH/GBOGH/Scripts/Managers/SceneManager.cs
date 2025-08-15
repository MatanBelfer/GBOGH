﻿using System.Collections.Generic;
<<<<<<< HEAD
=======
using EX04OOP.Interfaces;
>>>>>>> main
using GBOGH.Scripts.Interface;

namespace EX04OOP;

public static class SceneManager
{
    public static Scene CurrentScene;
    private static Dictionary<string, Scene> scenes = new Dictionary<string, Scene>();
    public static bool Exit { get; set; }
    public static bool IsLoading { get; set; }

    public static void ChangeScene(string scene)
    {
        DisableCurrentScene();
        EnableNextScene(scene);
    }

    public static void EnableScene(Scene scene)
    {
        CurrentScene = scene;
        CurrentScene.OnEnable();
    }

    private static void EnableNextScene(string scene)
    {
        CurrentScene = GetScene(scene);
        CurrentScene.OnEnable();

    }

    private static Scene GetScene(string scene)
    {
        return scenes[scene];
    }

    private static void DisableCurrentScene()
    { 
        IsLoading = true;
        CurrentScene?.OnDisable();
    }

    public static void AddScene(string name, Scene scene)
    {
        
        scenes.Add(name, scene);
    }

}