using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Person : MonoBehaviour
{
    [SerializeField] private WordButtom WordButtom;

    [SerializeField] private GameObject[] ActivElement = default;
    [SerializeField] private GameObject RoundPanel = default;
    [SerializeField] private GameObject[] Weapon = default;
    [SerializeField] private GameObject[] EnemyGameObj = default;

    [SerializeField] private Transform Lasttransform = default;
    //подтягимваються от сюда сейвы и туда же пишутся
    [SerializeField] private HP HP_Person = default;
    //Массивы аниматоров для выбора боссса и игрока
    public Animator[] GerlAnimator;
    public Animator[] EnyAnimator;

    [SerializeField] private Slider HP_Gerl = default;
    [SerializeField] private Text HP_Gerl_Text = default;
    [SerializeField] private Slider HP_Enemy = default;
    [SerializeField] private Text HP_Enemy_Text = default;
    [SerializeField] public float HP_G = 1;
    [HideInInspector]public float HP_E;
    [HideInInspector]public float DamagePers;
    [HideInInspector] public float DamgeEnemy;
    [HideInInspector]static public bool GameState = true;
    [HideInInspector] public float Deffence;
    [HideInInspector] public float Deffence_Standart_Lvl;
    
    //Бамблы
    [SerializeField] private GameObject Band_Text_Pers;
    [SerializeField] private Animator Band;
    [SerializeField] private GameObject Bamd_text_Eny;
    //текст для конца раунда
    [SerializeField] private Text Gold;
    [SerializeField] private Text Rubin;
    [SerializeField] private Text Point;
    [SerializeField] private Text Exp;
    [SerializeField] private Text EndRaund;
    [SerializeField] private Text NextLevel;
    private void OnEnable()
    {
        EventMeneger.GerlAttack1 += AttackGerl;
        EventMeneger.EnemyAttack1 += AttackEny;
    }
    private void OnDisable()
    {
        EventMeneger.GerlAttack1 -= AttackGerl;
        EventMeneger.EnemyAttack1 -= AttackEny;
    }
    private void Awake()
    {
        HP_Person.LoadData();
        GameState = true;
        HP_G = HP_Person.HP_Gerl;
        EnemyGameObj[HP_Person.NumberEnemy].SetActive(true);
        if(HP_Person.NumberEnemy == 0)
        {
            HP_E = HP_Person.HP_Spawn_Start*HP_Person.LVLPers;
        }
        else if(HP_Person.NumberEnemy == 1)
        {
            HP_E = HP_Person.HP_Pig_Start * HP_Person.LVLPers;
        }
        else if(HP_Person.NumberEnemy == 2)
        {
            HP_E = HP_Person.HP_Usakula_Start * HP_Person.LVLPers;
        }
        HP_Gerl.maxValue = HP_G;
        HP_Enemy.maxValue = HP_E;
        DamagePers = HP_Person.Damage_Sword[(int)HP_Person.NumberSworld];   
        Deffence = HP_Person.Deffens;
        Deffence_Standart_Lvl = Deffence;
        if (HP_Person.Skills[0])
        {
            ActivElement[0].SetActive(true);
            DamagePers +=(int)((DamagePers/100.0f)*5.0f);
        }
        Weapon[(int)HP_Person.NumberSworld].SetActive(true);
    }

    private void Update()
    {
        HP_Gerl.value = HP_G;
        HP_Gerl_Text.text = ((int)HP_G).ToString() + "/" + ((int)HP_Person.HP_Gerl).ToString();
        HP_Enemy.value = HP_E;
        HP_Enemy_Text.text = ((int)HP_E).ToString() + "/" + ((int)HP_Enemy.maxValue).ToString();
        if (GameState)
        {
          EndRound();
        }
       
    }
    public void AttackGerl()
    {
        GerlAnimator[0].SetTrigger("Attack");
        EnyAnimator[HP_Person.NumberEnemy].SetTrigger("Damage");
        HP_E -= DamagePers;
        Bamd_text_Eny.GetComponent<TextMesh>().text = ((int)DamagePers).ToString();
        Band.SetTrigger("Eny");
    }
    public void AttackEny()
    {
        EnyAnimator[HP_Person.NumberEnemy].SetTrigger("Attack");
        GerlAnimator[0].SetTrigger("Damage");
        DamgeEnemy = HP_Person.LVLPers * Random.Range(20, 50);
        HP_G -=(DamgeEnemy -(DamgeEnemy / 100.0f)*Deffence);
        Band_Text_Pers.GetComponent<TextMesh>().text = ((int)(DamgeEnemy - (DamgeEnemy / 100.0f) * Deffence)).ToString();
        Band.SetTrigger("Pers");
    }
    public void EndRound()
    {
        if (HP_G <= 0)
        {
            GerlAnimator[0].SetTrigger("Die");
            int Gold_Lose = HP_Person.LVLPers*Random.Range(10,30);
            if (HP_Person.Skills[11])
            {
                Gold_Lose += ((Gold_Lose / 100) * (24 + HP_Person.LVL_Skill[11]));
                HP_Person.Gold += Gold_Lose;
            }
            else
            {
                HP_Person.Gold += Gold_Lose;
            }
            Gold.text = Gold_Lose.ToString();
            int Rubin_Lose = 0;
            HP_Person.Rubin += Rubin_Lose;
            Rubin.text = Rubin_Lose.ToString();
            HP_Person.PointBook += WordButtom.Point_now_Battel;
            Point.text = WordButtom.Point_now_Battel.ToString();
            int EXP_lose = HP_Person.LVLPers*Random.Range(10,20);
            HP_Person.NowXP += EXP_lose;
            Exp.text = EXP_lose.ToString();
            //HP_Person.NowXP += 50;
            RoundPanel.SetActive(true);
            GameState = false;
            EndRaund.text = "В этот раз Усакула победил!" + "\n" + "Попробуйте улучшить оружие или запомнить больше волшебных слов ;)";
            if(HP_Person.NowXP >= HP_Person.NextLVLXP)
            {
                NextLevel.text = "НОВЫЙ УРОВЕНЬ!";
            }
            RoundPanel.transform.DOMove(Lasttransform.position, 1f);
            HP_Person.NextLVL();
            HP_Person.SaveData();

        }
        if (HP_E <= 0)
        {
            EnyAnimator[HP_Person.NumberEnemy].SetTrigger("Die");
            int Gold_W = HP_Person.LVLPers*Random.Range(80,100);
            if (HP_Person.Skills[11])
            {
                Gold_W += ((Gold_W / 100) * (24 + HP_Person.LVL_Skill[11]));
                HP_Person.Gold += Gold_W;
                
            }
            else
            {
                HP_Person.Gold += Gold_W;
            }
            Gold.text = Gold_W.ToString();
            int Rubin_W = 0;
            int Shois = Random.Range(0, 100);
            if (Shois <= 20)
            {
                Rubin_W = 1;
            }
            HP_Person.Rubin += Rubin_W;
            Rubin.text = Rubin_W.ToString();
            HP_Person.PointBook += WordButtom.Point_now_Battel;
            Point.text = WordButtom.Point_now_Battel.ToString();
            int EXP_W = HP_Person.LVLPers*Random.Range(80,110);
            HP_Person.NowXP += EXP_W;
            Exp.text = EXP_W.ToString();
            //HP_Person.NowXP += 250;
            RoundPanel.SetActive(true);
            GameState = false;
            EndRaund.text = "Вы победили! Так держать!";
            if (HP_Person.NowXP >= HP_Person.NextLVLXP)
            {
                NextLevel.text = "НОВЫЙ УРОВЕНЬ!";
            }
            RoundPanel.transform.DOMove(Lasttransform.position, 1f);
            HP_Person.NextLVL();
            HP_Person.SaveData();

        }
         //RoundPanel.SetActive(true);
         //GameState = false;
         //RoundPanel.transform.DOMove(Lasttransform.position, 1f);
         //HP_Person.NextLVL();
         //HP_Person.SaveData();
    }
    
}
