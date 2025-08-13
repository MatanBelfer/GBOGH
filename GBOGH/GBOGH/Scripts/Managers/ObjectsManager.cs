using System.Collections.Generic;
using GBOGH.Scripts.Core;

namespace GBOGH.Scripts.Managers;

public static class ObjectsManager
{
    public static int NextInt = 0;

    public static List<GameObject> SceneObjects = new List<GameObject>();

    private static readonly Dictionary<int, GameObject> ObjectsDict = new Dictionary<int, GameObject>();

    public static void AddObject(GameObject obj)
    {
        //TODO add check
        ObjectsDict.Add(obj.Index, obj);
    }

    public static void RemoveObject(GameObject obj)
    {
        //TODO add check
        ObjectsDict.Remove(obj.Index);
    }

    public static void RemoveObject(int index)
    {
        //TODO add check
        ObjectsDict.Remove(index);
    }
    
    public static GameObject GetObject(int index)
    {
        //TODO add checks 
        return ObjectsDict[index];
    }

    public static GameObject GetObject(string name)
    {
        foreach (var gameObject in SceneObjects)
        {
            if (gameObject.Name.Substring(gameObject.Name.IndexOf('_') + 1) == name)
                return gameObject;
        }

        return null;
    }
}