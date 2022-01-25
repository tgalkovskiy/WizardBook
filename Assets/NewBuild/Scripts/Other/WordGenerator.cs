using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class WordGenerator 
{
    public string[][] WordAll = new string[3][];
    private string[] WordRus = new string[6];
    private string[] WordEng = new string[6];
    private string[] WordBel = new string[6];
    public int CorrectWord;
    private WordDataBase dataBase;
    private List<string> engBase;
    private List<string> rusBase;
    private List<string> belBase;

    public WordGenerator(int lvlBook)
    {
        WordAll[0] = WordRus;
        WordAll[1] = WordEng;
        WordAll[2] = WordBel;
        string path = Path.Combine(Application.persistentDataPath, "WordBase.json");
        dataBase = JsonUtility.FromJson<WordDataBase>(File.ReadAllText(path));
        if(lvlBook == 1)
        {
            engBase = dataBase.eng1;
            rusBase = dataBase.rus1;
            belBase = dataBase.bel1;
        }
        if(lvlBook == 2)
        {
            engBase = dataBase.eng2;
            rusBase = dataBase.rus2;
            belBase = dataBase.bel2;
        }
        if(lvlBook == 3)
        {
            engBase = dataBase.eng3;
            rusBase = dataBase.rus3;
            belBase = dataBase.bel3;
        }
        if(lvlBook == 4)
        {
            engBase = dataBase.eng4;
            rusBase = dataBase.rus4;
            belBase = dataBase.bel4;
        }
        if(lvlBook == 5)
        {
            engBase = dataBase.eng5;
            rusBase = dataBase.rus5;
            belBase = dataBase.bel5;
        }
        if(lvlBook == 6)
        {
            engBase = dataBase.eng6;
            rusBase = dataBase.rus6;
            belBase = dataBase.bel6;
        }
        if(lvlBook == 7)
        {
            engBase = dataBase.eng7;
            rusBase = dataBase.rus7;
            belBase = dataBase.bel7;
        }
        LoadText();
    }
    public void LoadText()
    {
        int count = 0;
        int[] numbers = new int[6];
        for(int j =0; j < numbers.Length;)
        {
            var pob = UnityEngine.Random.Range(0, engBase.Count);
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
            WordRus[i] = rusBase[numbers[i]];
            WordEng[i] = engBase[numbers[i]];
            WordBel[i] = belBase[numbers[i]];
        }
        CorrectWord = UnityEngine.Random.Range(0, WordRus.Length);
        
    }

    
    
}
