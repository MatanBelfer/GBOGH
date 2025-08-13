using System.Collections.Generic;
using GBOGH.Scripts.Core;

namespace GBOGH.Scripts.Interface;

public interface IScene
{
    public delegate void SceneUnloadHandler();
    public event SceneUnloadHandler OnSceneUnload;

    public string Name { get; set; }
    public bool IsActive { get; set; }
    public List<GameObject> SceneObjects { get; set; }

    public void OnEnable();

    public void OnDisable();
}