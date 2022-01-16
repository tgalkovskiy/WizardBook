using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;


public class DataMap
{
    public bool[] enemyNumber;
}
[CreateAssetMenu(fileName = "MapSetting", menuName = "Map")]
public class Map : ScriptableObject
{
    public bool[] enemyNumber;
    public void SaveData()
    {
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "SaveMap.Json");
        DataMap data = new DataMap();
        data.enemyNumber = enemyNumber;
        File.WriteAllText(Path, JsonUtility.ToJson(data));
    }

    public void LoadData()
    {
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "SaveMap.Json");
        if (File.Exists(Path))
        {
            DataMap data = new DataMap();
            data = JsonUtility.FromJson<DataMap>(File.ReadAllText(Path));
            enemyNumber = data.enemyNumber;
        }
        else
        {
            enemyNumber[0] = true;
            for (int i = 1; i < enemyNumber.Length; i++)
            {
                enemyNumber[i] = false;
            }
        }
    }
}
