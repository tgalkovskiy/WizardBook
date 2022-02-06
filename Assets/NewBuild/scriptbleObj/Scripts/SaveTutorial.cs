
using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "Tutorial", menuName = "Tutorial")]
public class SaveTutorial : ScriptableObject
{
    private class  Data
    {
        public bool first_tutorial;
        public bool first_map;
        public bool first_fitgth;
        public bool first_victory;
        public bool first_lose;
        public bool Inventory;
        public bool Book;
    }
    [MultilineAttribute(5)][HeaderAttribute("tutorial home page")]public string[] homeText;
    public bool firstLaunchHome;
    [Space]
    [MultilineAttribute(5)][HeaderAttribute("tutorial map")]public string[] mapText;
    public bool firstLaunchMap;
    [Space] 
    [MultilineAttribute(5)] [HeaderAttribute("tutorial battle")] public string[] battleText;
    public bool firstLaunchBattle;
    [Space]
    [MultilineAttribute(5)][HeaderAttribute("tutorial first win")]public string[] winText;
    public bool firstWin;
    [Space]
    [MultilineAttribute(5)][HeaderAttribute("tutorial first lose")]public string[] loseText;
    public bool firstLose;
    
    public void SaveData()
    {
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "Savetutorial.Json");
        Data data = new Data();
        data.first_tutorial = firstLaunchHome;
        data.first_map = firstLaunchMap;
        data.first_fitgth = firstLaunchBattle;
        data.first_victory = firstWin;
        data.first_lose = firstLose;
        File.WriteAllText(Path, JsonUtility.ToJson(data));
    }

    public void LoadData()
    {
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "Savetutorial.Json");
        if (File.Exists(Path))
        {
            Data data = new Data();
            data = JsonUtility.FromJson<Data>(File.ReadAllText(Path));
            firstLaunchHome = data.first_tutorial;
            firstLaunchMap = data.first_map;
            firstLaunchBattle = data.first_fitgth;
            firstWin = data.first_victory;
            firstLose = data.first_lose;
        }
        else
        {
            firstLaunchHome = false;
            firstLaunchMap = false;
            firstLaunchBattle = false;
            firstWin = false;
            firstLose = false;
        }
    }
}
