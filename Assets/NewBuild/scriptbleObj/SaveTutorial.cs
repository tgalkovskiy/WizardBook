using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "Tutorial", menuName = "Tutorial")]
public class SaveTutorial : ScriptableObject
{
    public class  Data
    {
        public bool first_tutorial;
        public bool first_map;
        public bool first_fitgth;
        public bool first_victory;
        public bool first_lose;
        public bool Inventory;
        public bool Book;
    }

    public bool first_tutorial;
    public bool first_map;
    public bool first_fitgth;
    public bool first_victory;
    public bool first_lose;
    public bool Inventory;
    public bool Book;

    public void SaveData()
    {
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "Save_tutorial.Json");
        Data data = new Data();
        data.first_tutorial = first_tutorial;
        data.first_map = first_map;
        data.first_fitgth = first_fitgth;
        data.first_victory = first_victory;
        data.first_lose = first_lose;
        data.Inventory = Inventory;
        data.Book = Book;
        try
        {
            File.WriteAllText(Path, JsonUtility.ToJson(data));
        }
        catch
        {
            Debug.Log("not Save");
        }
        finally
        {
            Debug.Log("Save Done");
        }
    }

    public void LoadData()
    {
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "Save_tutorial.Json");
        if (File.Exists(Path))
        {
            Data data = new Data();
            data = JsonUtility.FromJson<Data>(File.ReadAllText(Path));
            first_tutorial = data.first_tutorial;
            first_map = data.first_map;
            first_fitgth = data.first_fitgth;
            first_victory = data.first_victory;
            first_lose = data.first_lose;
            Inventory = data.Inventory;
            Book = data.Book;
        }
        else
        {
            first_tutorial = false;
            first_map = false;
            first_fitgth = false;
            first_victory = false;
            first_lose = false;
            Inventory = false;
            Book = false;
        }
    }
}
