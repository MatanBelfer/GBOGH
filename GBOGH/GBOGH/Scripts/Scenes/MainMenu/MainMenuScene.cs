using System.Collections.Generic;
using EX04OOP;
using EX04OOP.Interfaces;
using GBOGH.Scripts.Scene.MainMenu;

namespace GBOGH.Scripts.Scenes.MainMenu;

public class MainMenuScene : IScene
{
    public event IScene.SceneUnloadHandler OnSceneUnload;
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public List<GameObject> SceneObjects { get; set; }

    public void OnEnable()
    {
        SceneObjects = new List<GameObject>();

        //TODO add menu buttons Start, Settings, Exit

        var startButton = new StartButton("Start");
        SceneObjects.Add(startButton);

        var settingsButton = new SettingsButton("Settings");
        SceneObjects.Add(settingsButton);

        var exitButton = new ExitButton("Exit");
        SceneObjects.Add(exitButton);
        InitSceneObjects();
    }

    public void OnDisable()
    {
        throw new System.NotImplementedException();
    }

    public void InitSceneObjects()
    {
        foreach (var obj in SceneObjects)
        {
            obj.Enable();
        }
    }
}