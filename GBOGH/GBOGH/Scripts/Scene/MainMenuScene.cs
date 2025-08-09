using System.Collections.Generic;
using EX04OOP;
using EX04OOP.Interfaces;
using Microsoft.Xna.Framework;

namespace GBOGH.Content.Scene;

public class MainMenuScene: IScene
{
    public event IScene.SceneUnloadHandler OnSceneUnload;
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public List<GameObject> SceneObjects { get; set; }
    public void OnEnable()
    {
        throw new System.NotImplementedException();
    }

    public void OnDisable()
    {
        throw new System.NotImplementedException();
    }
}