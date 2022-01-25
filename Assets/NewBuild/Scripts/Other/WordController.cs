
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WordController : MonoBehaviour
{
    public UiContainer uiContainer;
    [SerializeField] private GameConfig gameConfigPlayer;
    [SerializeField] private ChoiesLanguege ChoiesLanguege = default;
    [SerializeField] private Button[] WordButtomMas = default;
    public static bool Touch = false;
    private bool Shake_bool = false;
    private bool Wrong_Word_bool = false;
    private int Wrong_word_int = 0;
    public int Moves = 1;
    private float Timer = 15f;
    WordGenerator wordGenerator;
    
    [HideInInspector]public float timerInRaund;
    private void Awake()
    {
        wordGenerator = new WordGenerator(gameConfigPlayer.LVLBooK);
    }
    private void Start()
    {
        ChoiesLanguege.LoadData();
        Word();
        timerInRaund += gameConfigPlayer.Time_Game;    
    }
    private void Update()
    {
        if (BattleController.GameState)
        {
            Timer -= Time.deltaTime;
            uiContainer.timer.text = ((int)Timer).ToString();
            if (Timer <= 0)
            {
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
        if(!Touch && BattleController.GameState)
        {
            Touch = true;
            if (Buttoms == wordGenerator.CorrectWord)
            {
                WordButtomMas[Buttoms].GetComponent<Image>().sprite = uiContainer.correct;
                StartCoroutine(ChangeWordCorrect(Buttoms));
                StartCoroutine(Shake(1.4f));
            }
            else
            {
                WordButtomMas[Buttoms].GetComponent<Image>().sprite =uiContainer.wrong;
                WordButtomMas[wordGenerator.CorrectWord].GetComponent<Image>().sprite = uiContainer.correct;
                StartCoroutine(ChangeWordWrong(Buttoms));
                StartCoroutine(Shake(2.4f));
            }
        }
    }
    public void Word()
    {
        wordGenerator.LoadText();
        uiContainer.mainWord.text = wordGenerator.WordAll[ChoiesLanguege.Languge1][wordGenerator.CorrectWord];
        for(int i=0; i<WordButtomMas.Length; i++)
        {
            WordButtomMas[i].GetComponentInChildren<Text>().text = wordGenerator.WordAll[ChoiesLanguege.Languge2][i];
        }
        
    }
    public void Delete_Word()
    {
        List<Button> vs = new List<Button>() {WordButtomMas[0], WordButtomMas[1], WordButtomMas[2], WordButtomMas[3], WordButtomMas[4], WordButtomMas[5]};
        vs.RemoveAt(wordGenerator.CorrectWord);
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
        WordButtomMas[Number].GetComponent<Image>().sprite = uiContainer.original;
        EventManager.playerAction.Invoke();
    }
    public IEnumerator ChangeWordWrong(int Number)
    {
        yield return new WaitForSeconds(2);
        WordButtomMas[Number].GetComponent<Image>().sprite = uiContainer.original;
        WordButtomMas[wordGenerator.CorrectWord].GetComponent<Image>().sprite = uiContainer.original;
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
        uiContainer.UpdateButtonSkills();
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
