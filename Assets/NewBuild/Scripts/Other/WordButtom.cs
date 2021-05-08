using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordButtom : MonoBehaviour
{
    [SerializeField] private HP HP_PERS;
    [SerializeField] private WrongWord _wrongWord = default;
    [SerializeField] WordLoad WordLoad;
    [SerializeField] private ChoiesLanguege ChoiesLanguege = default;
    [SerializeField] private Button[] WordButtomMas = default;
    [SerializeField] private Text NowWord = default;
    [SerializeField] private Text TimerText = default;
    public static bool Touch = false;
    private bool Shake_bool = false;
    private bool Wrong_Word_bool = false;
    private int Wrong_word_int = 0;
    public int Moves = 0;
    //[HideInInspector] static public string CorrectWord;
    private float Timer = 15f;
    
    [HideInInspector]public float Deff_Timer;
    [HideInInspector] public int Point_now_Battel = 0;
    
   
    private void Start()
    {
        ChoiesLanguege.LoadData();
        Debug.Log(ChoiesLanguege.Languge1 + " " + ChoiesLanguege.Languge2);
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
        EventMeneger.GerlAttack1 -= MovesCount;
        EventMeneger.EnemyAttack1 -= MovesCount;
        EventMeneger.GerlAttack1 -= WordLoad.LoadText;
        EventMeneger.EnemyAttack1 -= WordLoad.LoadText;
        EventMeneger.GerlAttack1 -= Word;
        EventMeneger.EnemyAttack1 -= Word;
    }
    private void Update()
    {
        if (Person.GameState)
        {
            Timer -= Time.deltaTime;
            TimerText.text = ((int) Timer).ToString();
            if (Timer <= 0)
            {
                Timer = Deff_Timer;
                EventMeneger.EnemyAttack1.Invoke();
            }
        }
        if (Shake_bool)
        {
            Vector3 Shake = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
            Camera.main.transform.localPosition += Shake;
        }
        
    }
    public void ButtomWord(int Buttoms)
    {
        //получение стринги в кнопке
        //string Word = WordButtomMas[Buttoms].GetComponentInChildren<Text>().text;
        //запуск ивентов
        if (!Touch && Person.GameState)
        {
            Touch = true;
            if (Buttoms == WordLoad.CorrectWord)
            {
                WordButtomMas[Buttoms].GetComponent<Image>().color = Color.green;
                StartCoroutine(ChangeWordCorrect(Buttoms));
                StartCoroutine(Shake(1.4f));
                Point_now_Battel += 1;
                //EventMeneger.GerlAttack1.Invoke();
                //Timer = 15f;
                //CountCorrectWord += 1;
                HP_PERS.Now_BOOK_XP += 1;
                if (Wrong_Word_bool)
                {
                    _wrongWord.Wrong_Word_Ru.RemoveAt(Wrong_word_int);
                    _wrongWord.Wrong_Word_Eng.RemoveAt(Wrong_word_int);
                    _wrongWord.Wrong_Word_BEL.RemoveAt(Wrong_word_int);
                    _wrongWord.Save_wrong_Word();
                    Wrong_Word_bool = false;
                }
            }
            else
            {
                Point_now_Battel = 0;
                WordButtomMas[Buttoms].GetComponent<Image>().color = Color.red;
                WordButtomMas[WordLoad.CorrectWord].GetComponent<Image>().color = Color.green;
                StartCoroutine(ChangeWordWrong(Buttoms));
                StartCoroutine(Shake(2.4f));
                //запись ошибок
                _wrongWord.Wrong_Word_Ru.Add(WordLoad.WordAll[0][WordLoad.CorrectWord]);
                _wrongWord.Wrong_Word_Eng.Add(WordLoad.WordAll[1][WordLoad.CorrectWord]);
                _wrongWord.Wrong_Word_BEL.Add(WordLoad.WordAll[2][WordLoad.CorrectWord]);
                _wrongWord.Save_wrong_Word();
                Wrong_Word_bool = false;
                    
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
        int prop = Random.Range(0, 100);
        if (prop > 90)
        {
            //It_wrong_word();
        }
        NowWord.text = WordLoad.WordAll[ChoiesLanguege.Languge1][WordLoad.CorrectWord];
        for(int i=0; i<WordButtomMas.Length; i++)
        {
            WordButtomMas[i].GetComponentInChildren<Text>().text = WordLoad.WordAll[ChoiesLanguege.Languge2][i];
            if (WordLoad.WordAll[ChoiesLanguege.Languge2][i].Length > 8)
            {
                WordButtomMas[i].GetComponentInChildren<Text>().fontSize = 34;
            }
            else
            {
                WordButtomMas[i].GetComponentInChildren<Text>().fontSize = 40;
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
        
        yield return new WaitForSeconds(2);
        Time.timeScale = 1;
        WordButtomMas[Number].GetComponent<Image>().color = Color.white;
        WordButtomMas[WordLoad.CorrectWord].GetComponent<Image>().color = Color.white;
        EventMeneger.EnemyAttack1.Invoke();
        Timer = Deff_Timer;
        Touch = false;
    }


    IEnumerator Shake(float time)
    {
        Vector3 Origin_trnasform = Camera.main.transform.localPosition;
        yield return new WaitForSeconds(time);
        Shake_bool = true;
        yield return new WaitForSeconds(0.4f);
        Shake_bool = false;
        Camera.main.transform.localPosition = Origin_trnasform;
    }
    public void MovesCount()
    {
        Moves += 1;
        if(SkillManeger.Buttom_Arson_Image != null)
        {
           SkillManeger.Buttom_Arson_Image.fillAmount += 0.166f; 
        }
        if(SkillManeger.Buttom_Deffence != null)
        {
            SkillManeger.Buttom_Deffence.fillAmount +=1/(0.01f+SkillManeger.Cooldown_Deff);
        }
        if(SkillManeger.Buttom_Time_Stop != null)
        {
            SkillManeger.Buttom_Time_Stop.fillAmount +=1/(0.01f+SkillManeger.CoolDown_Time);
        }

        if (SkillManeger.Buttom_Watter != null)
        {
            SkillManeger.Buttom_Watter.fillAmount +=1/(0.01f+SkillManeger.Cooldown_Watter);
        }
        
    }

    private void It_wrong_word()
    {
        _wrongWord.Load_wrong_word();
        if (_wrongWord.Wrong_Word_Ru.Count > 0)
        {
            int number_rwong_word = Random.Range(0, _wrongWord.Wrong_Word_Ru.Count);
            Wrong_Word_bool = true;
            Wrong_word_int = number_rwong_word;
            WordLoad.WordAll[0][WordLoad.CorrectWord] = _wrongWord.Wrong_Word_Ru[number_rwong_word];
            WordLoad.WordAll[1][WordLoad.CorrectWord] = _wrongWord.Wrong_Word_Eng[number_rwong_word];
            WordLoad.WordAll[2][WordLoad.CorrectWord] = _wrongWord.Wrong_Word_BEL[number_rwong_word];
        }
    }
    
    
    
}
