using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordButtom : MonoBehaviour
{
    [SerializeField] private HP HP_PERS;
    [SerializeField] WordLoad WordLoad;
    [SerializeField] private ChoiesLanguege ChoiesLanguege = default;
    [SerializeField] private Button[] WordButtomMas = default;
    [SerializeField] private Text NowWord = default;
    [SerializeField] private Text TimerText = default;
    private bool Touch = false;
    public int Moves = 0;
    //[HideInInspector] static public string CorrectWord;
    private float Timer = 15f;
    [HideInInspector]public float Deff_Timer;
    [HideInInspector] public int Point_now_Battel = 0;
   
    private void Start()
    {
        Word();
        //Timer = HP_PERS.Time_Game;
        Deff_Timer += HP_PERS.Time_Game;    
    }
    private void OnEnable()
    {
        EventMeneger.GerlAttack1 += MovesCount;
        EventMeneger.EnemyAttack1 += MovesCount;
        EventMeneger.GerlAttack1 += WordLoad.LoadText;
        EventMeneger.EnemyAttack1 += WordLoad.LoadText;
        EventMeneger.GerlAttack1 += Word;
        EventMeneger.EnemyAttack1 += Word;
    }
    private void OnDisable()
    {
        
        EventMeneger.GerlAttack1 += MovesCount;
        EventMeneger.EnemyAttack1 += MovesCount;
        EventMeneger.GerlAttack1 -= WordLoad.LoadText;
        EventMeneger.EnemyAttack1 -= WordLoad.LoadText;
        EventMeneger.GerlAttack1 -= Word;
        EventMeneger.EnemyAttack1 -= Word;
    }
    private void Update()
    {
        Timer -= Time.deltaTime;
        TimerText.text = ((int)Timer).ToString();
        if (Timer <= 0)
        {
            Timer = Deff_Timer;
            EventMeneger.EnemyAttack1.Invoke();
        }
        
    }
    public void ButtomWord(int Buttoms)
    {
        //получение стринги в кнопке
        //string Word = WordButtomMas[Buttoms].GetComponentInChildren<Text>().text;
        //запуск ивентов
        if (!Touch)
        {
            Touch = true;
            if (Buttoms == WordLoad.CorrectWord)
                {
                    WordButtomMas[Buttoms].GetComponent<Image>().color = Color.green;
                    StartCoroutine(ChangeWordCorrect(Buttoms));
                    //EventMeneger.GerlAttack1.Invoke();
                    //Timer = 15f;
                    //CountCorrectWord += 1;
                    HP_PERS.Now_BOOK_XP += 1;
                }
                else
                {
                    WordButtomMas[Buttoms].GetComponent<Image>().color = Color.red;
                    WordButtomMas[WordLoad.CorrectWord].GetComponent<Image>().color = Color.green;
                    StartCoroutine(ChangeWordWrong(Buttoms));
                    //EventMeneger.EnemyAttack1.Invoke();
                    //Timer = 15f;
                    //CountCorrectWord = 0;
                }
                //if(CountCorrectWord == 5)
                //{

                //    //HP_PERS.PointBook += 1;
                //    //Point_now_Battel += 1;
                //    CountCorrectWord = 0;
        }
    }
    /// <summary>
    /// Обновление слов
    /// </summary>
    public void Word()
    {
        var A = EventMeneger.GerlAttack1.GetInvocationList();
        NowWord.text = WordLoad.WordAll[ChoiesLanguege.Languge1][WordLoad.CorrectWord];
        for(int i=0; i<WordButtomMas.Length; i++)
        {
            WordButtomMas[i].GetComponentInChildren<Text>().text = WordLoad.WordAll[ChoiesLanguege.Languge2][i];
            if (WordLoad.WordAll[ChoiesLanguege.Languge2][i].Length > 8)
            {
                WordButtomMas[i].GetComponentInChildren<Text>().fontSize = 40;
            }
            else
            {
                WordButtomMas[i].GetComponentInChildren<Text>().fontSize = 55;
            }
        }
    }
    public void Delete_Word()
    {
        List<Button> vs = new List<Button>() {WordButtomMas[0], WordButtomMas[1], WordButtomMas[2], WordButtomMas[3], WordButtomMas[4], WordButtomMas[5]};
        vs.RemoveAt(WordLoad.CorrectWord);
        int k = 0;
        int l = 0;
        while (k==l)
        {
            k = Random.Range(0, vs.Count);
            l = Random.Range(0, vs.Count);
        }
        vs[k].GetComponentInChildren<Text>().text = "";
        vs[l].GetComponentInChildren<Text>().text = "";
    }

    public IEnumerator ChangeWordCorrect(int Number)
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 1;
        WordButtomMas[Number].GetComponent<Image>().color = Color.white;
        EventMeneger.GerlAttack1.Invoke();
        Timer = Deff_Timer;
        Touch = false;
    }
    public IEnumerator ChangeWordWrong(int Number)
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 1;
        WordButtomMas[Number].GetComponent<Image>().color = Color.white;
        WordButtomMas[WordLoad.CorrectWord].GetComponent<Image>().color = Color.white;
        EventMeneger.EnemyAttack1.Invoke();
        Timer = Deff_Timer;
        Touch = false;
    }
    public void MovesCount()
    {
        Moves += 1;
    }
}
