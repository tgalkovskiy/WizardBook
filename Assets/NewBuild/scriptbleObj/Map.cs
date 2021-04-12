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
        public float X1;
        public float Y1;
        public float Z1;
        
        public int Number_Max2;
        public float X2;
        public float Y2;
        public float Z2;
        
        public int Number_Max3;
        public float X3;
        public float Y3;
        public float Z3;
        
    }
    public int Number_Max1;
    public float X1;
    public float Y1;
    public float Z1;
    
    public int Number_Max2;
    public float X2;
    public float Y2;
    public float Z2;
    
    public int Number_Max3;
    public float X3;
    public float Y3;
    public float Z3;
    
    public int Number_now;
    public int Now_map;
    public void SaveData()
    {
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "Save_Map.Json");
        Data_Map data = new Data_Map();
        
        data.Number_Max1 = Number_Max1;
        data.X1 = X1;
        data.Y1 = Y1;
        data.Z1 = Z1;
        
        data.Number_Max2 = Number_Max2;
        data.X2 = X2;
        data.Y2 = Y2;
        data.Z2 = Z2;
        
        data.Number_Max3 = Number_Max3;
        data.X3 = X3;
        data.Y3 = Y3;
        data.Z3 = Z3;
        
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
            X1 = data.X1;
            Y1 = data.Y1;
            Z1 = data.Z1;
            
            Number_Max2 = data.Number_Max2;
            X2 = data.X2;
            Y2 = data.Y2;
            Z2 = data.Z2;
            
            Number_Max3 = data.Number_Max3;
            X3 = data.X3;
            Y3 = data.Y3;
            Z3 = data.Z3;
            
        }
        else
        {
            Debug.Log("No Save mapSetting");
            Number_Max1 = 0;
            X1 = 18.52f;
            Y1 = 0.245f;
            Z1 = 8.24f;
            
            Number_Max2 = 0;
            X2 = 18.52f;
            Y2 = 0.245f;
            Z2 = 8.24f;
            
            Number_Max3 = 0;
            X3 = 18.52f;
            Y3 = 0.245f;
            Z3 = 8.24f;
        }
    }
}
