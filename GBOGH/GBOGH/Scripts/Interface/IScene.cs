using System.Collections.Generic;
using EX04OOP.Core;

namespace EX04OOP.Interfaces;

public interface IScene
{
    public delegate void SceneUnloadHandler();

    public event SceneUnloadHandler OnSceneUnload;

    public string Name { get; set; }
    public bool IsActive { get; set; }
    public List<GameObject> SceneObjects { get; set; }

    public void OnEnable();

    public void OnDisable();

    public void InitSceneObjects();
}