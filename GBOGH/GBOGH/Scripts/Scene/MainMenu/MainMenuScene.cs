using System.Collections.Generic;
using EX04OOP;
using EX04OOP.Interfaces;
using GBOGH.Scripts.Scene.Mainmenu;

namespace GBOGH.Scripts.Scene.MainMenu;

public class MainMenuScene : IScene
{
    public event IScene.SceneUnloadHandler OnSceneUnload;
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public List<GameObject> SceneObjects { get; set; }

    public void OnEnable()
    {
        //TODO add menu buttons Start, Settings, Exit

        var startButton = new StartButton();
        
        var settingsButton = new SettingsButton();

        var exitButton = new ExitButton();

    }

    public void OnDisable()
    {
        throw new System.NotImplementedException();
    }
}