using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordButtom : MonoBehaviour
{
    [SerializeField] private SkillManeger skillManeger;
    [SerializeField] private Sprite wrong;
    [SerializeField] private Sprite correct;
    [SerializeField] private Sprite original;
    [SerializeField] private GameConfig gameConfigPers;
    [SerializeField] WordLoad WordLoad;
    [SerializeField] private ChoiesLanguege ChoiesLanguege = default;
    [SerializeField] private Button[] WordButtomMas = default;
    [SerializeField] private Text NowWord = default;
    [SerializeField] private Text TimerText = default;
    public static bool Touch = false;
    private bool Shake_bool = false;
    private bool Wrong_Word_bool = false;
    private int Wrong_word_int = 0;
    public int Moves = 1;
    //[HideInInspector] static public string CorrectWord;
    private float Timer = 15f;
    
    [HideInInspector]public float timerInRaund;
    [HideInInspector] public int Point_now_Battel = 0;
    
    private void Start()
    {
        ChoiesLanguege.LoadData();
        Word();
        timerInRaund += gameConfigPers.Time_Game;    
    }
    private void Update()
    {
        if (Person.GameState)
        {
            Timer -= Time.deltaTime;
            TimerText.text = ((int)Timer).ToString();
            if (Timer <= 0)
            {
                //Timer = timerInRaund;
                EventManager.enemyAction.Invoke();
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
        if (!Touch && Person.GameState)
        {
            Touch = true;
            if (Buttoms == WordLoad.CorrectWord)
            {
                WordButtomMas[Buttoms].GetComponent<Image>().sprite = correct;
                StartCoroutine(ChangeWordCorrect(Buttoms));
                StartCoroutine(Shake(1.4f));
                Point_now_Battel += 1;
            }
            else
            {
                Point_now_Battel = 0;
                WordButtomMas[Buttoms].GetComponent<Image>().sprite =wrong;
                WordButtomMas[WordLoad.CorrectWord].GetComponent<Image>().sprite = correct;
                StartCoroutine(ChangeWordWrong(Buttoms));
                StartCoroutine(Shake(2.4f));
            }
        }
    }
    /// <summary>
    /// Обновление слов
    /// </summary>
    public void Word()
    {
        NowWord.text = WordLoad.WordAll[ChoiesLanguege.Languge1][WordLoad.CorrectWord];
        for(int i=0; i<WordButtomMas.Length; i++)
        {
            WordButtomMas[i].GetComponentInChildren<Text>().text = WordLoad.WordAll[ChoiesLanguege.Languge2][i];
            if (WordLoad.WordAll[ChoiesLanguege.Languge2][i].Length > 8)
            {
                //WordButtomMas[i].GetComponentInChildren<Text>().fontSize = 34;
            }
            else
            {
                //WordButtomMas[i].GetComponentInChildren<Text>().fontSize = 40;
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
        WordButtomMas[Number].GetComponent<Image>().sprite = original;
        EventManager.playerAction.Invoke();
    }
    public IEnumerator ChangeWordWrong(int Number)
    {
        yield return new WaitForSeconds(2);
        WordButtomMas[Number].GetComponent<Image>().sprite = original;
        WordButtomMas[WordLoad.CorrectWord].GetComponent<Image>().sprite = original;
        EventManager.enemyAction.Invoke();
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

    public void BattleTimer()
    {
        Time.timeScale = 1;
        var chanceTimer = Random.Range(0, 100);
        if (chanceTimer < 40) Timer = timerInRaund;
        if (chanceTimer > 40 && chanceTimer < 70) Timer = timerInRaund - 5;
        if (chanceTimer > 70) Timer = timerInRaund - 10;
        Touch = false;
    }
}
