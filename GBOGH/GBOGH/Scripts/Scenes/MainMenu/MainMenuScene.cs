using System.Collections.Generic;
using EX04OOP;
using EX04OOP.Interfaces;
using GBOGH.Scripts.Interface;
using GBOGH.Scripts.Scene.MainMenu;

namespace GBOGH.Scripts.Scenes.MainMenu;

public class MainMenuScene : Interface.Scene
{
    public event Interface.Scene.SceneUnloadHandler OnSceneUnload;
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public override void OnEnable()
    {
        SceneObjects = new Dictionary<int, GameObject>();

        var startButton = new StartButton("Start");
        SceneObjects.Add(startButton.Index, startButton);

        var settingsButton = new SettingsButton("Settings");
        SceneObjects.Add(settingsButton.Index, settingsButton);

        var exitButton = new ExitButton("Exit");
        SceneObjects.Add(exitButton.Index, exitButton);
        Init();
    }

    public override void Init()
    {
        foreach (var obj in SceneObjects)
        {
            obj.Value.Enable();
        }

        
    }

    public override void OnDisable()
    {
        foreach (var obj in SceneObjects)
        {
            obj.Value.Disable();
        }
    }

}