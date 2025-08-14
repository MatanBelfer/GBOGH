using System.Collections.Generic;
using EX04OOP;

namespace GBOGH.Scripts.Interface;

public abstract class Scene
{
    public delegate void SceneUnloadHandler();

    public event SceneUnloadHandler OnSceneUnload;

    public string Name { get; set; }
    public bool IsActive { get; set; }
    public Dictionary<int, GameObject> SceneObjects { get; set; }

    public abstract void OnEnable();

    public abstract void Init();
    public abstract void OnDisable();
}