using System;
using System.IO;
using UnityEngine;
using SimpleJSON;
using System.Linq;

[Serializable]
public class WordLoad : MonoBehaviour
{
    //глобальный массив для всех слов
    [SerializeField] private GameConfig personGameConfig = default;
    private string AllJson;
    [HideInInspector]public string[][] WordAll = new string[3][];
    private string[] WordRus = new string[6];
    private string[] WordEng = new string[6];
    private string[] WordBel = new string[6];
    [HideInInspector] public int CorrectWord;
    private float LVLBOOK;
    private WordDataBase dataBase;
    private void Awake()
    {
        WordAll[0] = WordRus;
        WordAll[1] = WordEng;
        WordAll[2] = WordBel;
        string path = Path.Combine(Application.persistentDataPath, "WordBase.json");
        dataBase = JsonUtility.FromJson<WordDataBase>(File.ReadAllText(path));
        //WordDataBase dataBase = new WordDataBase();
        /*LVLBOOK = personGameConfig.lvlEnemy;
        WWW reader = new WWW(Path);
        AllJson = reader.text;
        if(reader.text.Length > 0)
        {
           AllJson = reader.text;
           personGameConfig.Word = reader.text;
        }
        else
        {
            AllJson = personGameConfig.Word;
        }#1#*/
        LoadText();

    }
    public void LoadText()
    {
        int count =0;
        int[] numbers = new int[6];
        if (personGameConfig.LVLBooK == 1)
        {
            count = dataBase.eng1.Count;
        }
        //JSONNode OpenJson = JSON.Parse(AllJson);
        //string LVLBOOKSTRING = LVLBOOK.ToString();
        //var nums = Enumerable.Range(0, OpenJson["Word"]["Rus"][LVLBOOKSTRING].Count).ToList();
        //Заполение массива слов
        for(int j =0; j < numbers.Length;)
        {
            var pob = UnityEngine.Random.Range(0, count);
            int k;
            for(k =0; k<j; k++)
            {
                if(pob == numbers[k])
                {
                    break;
                }
            }
            if (k == j)
            {
                numbers[j] = pob;
                j++;
            }
        }
        for (int i = 0; i < WordEng.Length; i++)
        {
            var pob = UnityEngine.Random.Range(0, numbers.Length);
            WordRus[i] = dataBase.rus1[numbers[i]]; //OpenJson["Word"]["Rus"][LVLBOOKSTRING][numbers[i]].Value;
            WordEng[i] = dataBase.eng1[numbers[i]]; //OpenJson["Word"]["ENG"][LVLBOOKSTRING][numbers[i]].Value;
            WordBel[i] = dataBase.bel1[numbers[i]]; //OpenJson["Word"]["BEL"][LVLBOOKSTRING][numbers[i]].Value;
            //Debug.Log(WordRus[i] + " " + WordEng[i] + " " + WordBel[i]);
        }
        CorrectWord = UnityEngine.Random.Range(0, WordRus.Length);
        
    }

    
    
}
