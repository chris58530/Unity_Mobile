using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    public static void SaveByJson(string fileName , object data)
    {
        var json = JsonUtility.ToJson(data);    
        var path = Path.Combine(Application.persistentDataPath,fileName);

        File.WriteAllText(path,json); 
    }
    public static T LoadFormJson<T>(string fileName)
    {
        var path = Path.Combine(Application.persistentDataPath ,fileName);
        var json = File.ReadAllText(path);

        var data = JsonUtility.FromJson<T>(json);

        return data;
    }
    public static void DeleteSaveFile(string fileName)
    {
        var path = Path.Combine (Application.persistentDataPath ,fileName);

        File.Delete(path);
        Debug.LogWarning("Delete : "+fileName);
    }
}
