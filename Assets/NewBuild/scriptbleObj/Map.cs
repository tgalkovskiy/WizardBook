using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[CreateAssetMenu(fileName = "MapSetting", menuName = "Map")]
public class Map : ScriptableObject
{
    public class Data_Map
    {
        public int Number_Max1;
        public int Number_Max2;
        public int Number_Max3;
    }
    public int Number_Max1;
    public int Number_Max2;
    public int Number_Max3;
    public int Number_now;
    public int Now_map;
    public void SaveData()
    {
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "Save_Map.Json");
        Data_Map data = new Data_Map();
        data.Number_Max1 = Number_Max1;
        data.Number_Max2 = Number_Max2;
        data.Number_Max3 = Number_Max3;
        try
        {
            File.WriteAllText(Path, JsonUtility.ToJson(data));
        }
        catch
        {
            Debug.Log("not Save_Map");
        }
        finally
        {
            Debug.Log("Save Done Map");
        }
    }

    public void LoadData()
    {
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "Save_Map.Json");
        if (File.Exists(Path))
        {
            Data_Map data = new Data_Map();
            data = JsonUtility.FromJson<Data_Map>(File.ReadAllText(Path));
            Number_Max1 = data.Number_Max1;
            Number_Max2 = data.Number_Max2;
            Number_Max3 = data.Number_Max3;
        }
        else
        {
            Debug.Log("No Save");
            Number_Max1 = 0;
            Number_Max2 = 0;
            Number_Max3 = 0;
        }
    }
}
