using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[CreateAssetMenu(fileName = "Languge", menuName = "languge")]

public class ChoiesLanguege : ScriptableObject
{
    public class DataLang
    {
        public int Languge1;
        public int Languge2;
    }
    
    public int Languge1;
    public int Languge2;


    public void SaveData()
    {
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "SaveLang.Json");
        DataLang data = new DataLang();
        data.Languge1 = Languge1;
        data.Languge2 = Languge2;
        try
        {
            File.WriteAllText(Path, JsonUtility.ToJson(data));
        }
        catch
        {
            //Debug.Log("not Save");
        }
        finally
        {
            //Debug.Log("Save Done");
        }
    }

    public void LoadData()
    {
        //Debug.Log(1);
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "SaveLang.Json");
        if (File.Exists(Path))
        {
            DataLang data = new DataLang();
            data = JsonUtility.FromJson<DataLang>(File.ReadAllText(Path));
            Languge1 = data.Languge1;
            Languge2 = data.Languge2;
            //Debug.Log(2);
        }
        else
        {
            Languge1 = 1;
            Languge2 = 0;
        }
    }
}
