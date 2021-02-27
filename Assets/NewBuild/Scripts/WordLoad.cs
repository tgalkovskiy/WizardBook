using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;
using System.Text;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Linq;

[Serializable]
public class WordLoad : MonoBehaviour
{
    public Text Test;
    //глобальный массив для всех слов
    [SerializeField] private HP Person_HP;
    private string Path = Application.streamingAssetsPath + "/TestJsnon.Jsnon";
    private string AllJson;
    [HideInInspector]public string[][] WordAll = new string[3][];
    private string[] WordRus = new string[6];
    private string[] WordEng = new string[6];
    private string[] WordBel = new string[6];
    [HideInInspector] public int CorrectWord;
    private float LVLBOOK;
    private void Awake()
    {
        WordAll[0] = WordRus;
        WordAll[1] = WordEng;
        WordAll[2] = WordBel;
        LVLBOOK = Person_HP.LVLBooK+1;
        WWW reader = new WWW(Path);
        AllJson = reader.text;
        if(reader.text.Length > 0)
        {
           AllJson = reader.text;
           Person_HP.Word = reader.text;
        }
        else
        {
            AllJson = Person_HP.Word;
        }
        LoadText();
    }
    private void OnEnable()
    {
        EventMeneger.GerlAttack1 += LoadText;
        EventMeneger.EnemyAttack1 += LoadText; 
    }
    private void OnDisable()
    {
        EventMeneger.GerlAttack1 -= LoadText;
        EventMeneger.EnemyAttack1 -= LoadText;
    }
    /// <summary>
    /// случайная сортировка слов для кнопок
    /// </summary>
    /// <param name="Mas"></param>
    //private void RandomSort(string[] Mas)
    //{
    //    System.Random rand = new System.Random();
    //    for (int i = Mas.Length - 1; i >= 1; i--)
    //    {
    //        int j = rand.Next(i + 1);
    //        // обменять значения data[j] и data[i]
    //        var temp = Mas[j];
    //        Mas[j] = Mas[i];
    //        Mas[i] = temp;
    //    }
    //}
    private void LoadText()
    {
        JSONNode OpenJson = JSON.Parse(AllJson);
        string LVLBOOKSTRING = LVLBOOK.ToString();
        var nums = Enumerable.Range(0, OpenJson["Word"]["Rus"][LVLBOOKSTRING].Count).ToList();
        //Debug.Log(nums.Count + " " + OpenJson["Word"]["Rus"][LVLBOOKSTRING].Count);
        //Заполение массива слов
        int[] Numbers = new int[6];
        for(int j =0; j < Numbers.Length;)
        {
            var pob = UnityEngine.Random.Range(0, nums.Count);
            int k;
            for(k =0; k<j; k++)
            {
                if(pob == Numbers[k])
                {
                    break;
                }
            }
            if (k == j)
            {
                Numbers[j] = pob;
                j++;
            }
        }
        for (int i = 0; i < WordEng.Length; i++)
        {
            var pob = UnityEngine.Random.Range(0, nums.Count);
            WordRus[i] = OpenJson["Word"]["Rus"][LVLBOOKSTRING][Numbers[i]].Value;
            WordEng[i] = OpenJson["Word"]["ENG"][LVLBOOKSTRING][Numbers[i]].Value;
            WordBel[i] = OpenJson["Word"]["BEL"][LVLBOOKSTRING][Numbers[i]].Value;
        }
        CorrectWord = UnityEngine.Random.Range(0, WordRus.Length);
    }
}
