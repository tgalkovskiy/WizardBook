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

    [SerializeField] private Map Map_Setting = default;
    //Массивы аниматоров для выбора боссса и игрока
    public Animator[] GerlAnimator;
    //public Animator[] EnyAnimator;
    
    [SerializeField] private Slider HP_Gerl = default;
    [SerializeField] private Text HP_Gerl_Text = default;
    [SerializeField] private Slider HP_Enemy = default;
    [SerializeField] private Text HP_Enemy_Text = default;
    [SerializeField] public float HP_G = 1;
    [HideInInspector]public float HP_E;
    [HideInInspector]public float DamagePers;
    [HideInInspector]public float DamgeEnemy;
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
    
    private GameObject Enemy;
    private Animator Animator_Animy;
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
        HP_G = HP_Person.HP_Gerl + HP_Person.Property_W[1]+ HP_Person.Property_A[1]+HP_Person.Property_O[0];
        HP_E = HP_Person.HP_Enemy;
        DamgeEnemy = HP_Person.Damage;
        Enemy= Instantiate(EnemyGameObj[HP_Person.NumberEnemy]);
        Animator_Animy = Enemy.GetComponent<Animator>();
        //EnemyGameObj[HP_Person.NumberEnemy].SetActive(true);
        HP_Gerl.maxValue = HP_G;
        HP_Enemy.maxValue = HP_E;
        DamagePers = HP_Person.Property_W[0] + HP_Person.Property_O[1];   
        Deffence = HP_Person.Property_A[0] + HP_Person.Property_O[2];
        Deffence_Standart_Lvl = Deffence;
        if (HP_Person.Skills[0])
        {
            ActivElement[0].SetActive(true);
            DamagePers +=(int)((DamagePers/100.0f)*5.0f+5*HP_Person.LVL_Skill[0]);
        }
        Weapon[(int)HP_Person.NumberSworld].SetActive(true);
    }

    private void Update()
    {
        HP_Gerl.value = HP_G;
        HP_Gerl_Text.text = (HP_G).ToString() + "/" + (HP_Person.HP_Gerl + HP_Person.Property_W[1] + HP_Person.Property_A[1] + HP_Person.Property_O[0]).ToString();
        HP_Enemy.value = HP_E;
        HP_Enemy_Text.text = (HP_E).ToString() + "/" + (HP_Enemy.maxValue).ToString();
        if (GameState)
        {
          EndRound();
        }
       
    }
    public void AttackGerl()
    {
        GerlAnimator[0].SetTrigger("Attack");
        Animator_Animy.SetTrigger("Damage");
        HP_E -= DamagePers;
        Bamd_text_Eny.GetComponent<TextMesh>().text = (DamagePers).ToString();
        Band.SetTrigger("Eny");
    }
    public void AttackEny()
    {
        Animator_Animy.SetTrigger("Attack");
        GerlAnimator[0].SetTrigger("Damage");
        HP_G -=DamgeEnemy-Deffence;
        Band_Text_Pers.GetComponent<TextMesh>().text = (DamgeEnemy - Deffence).ToString();
        Band.SetTrigger("Pers");
    }
    public void EndRound()
    {
        if (HP_G <= 0)
        {
            GerlAnimator[0].SetTrigger("Die");
            int Gold_Lose = HP_Person.Gold_enemy/10;
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
            //HP_Person.PointBook += WordButtom.Point_now_Battel;
            //Point.text = WordButtom.Point_now_Battel.ToString();
            int EXP_lose = HP_Person.Exp_enemy/10;
            HP_Person.NowXP += EXP_lose;
            Exp.text = EXP_lose.ToString();
            //HP_Person.NowXP += 50;
            RoundPanel.SetActive(true);
            GameState = false;
            EndRaund.text = "В этот раз враг победил!" + "\n" + "Попробуйте улучшить оружие или запомнить больше волшебных слов!)";
            if(HP_Person.NowXP >= HP_Person.NextLVLXP)
            {
                NextLevel.text = "НОВЫЙ УРОВЕНЬ!";
                HP_Person.NextLVL();
            }
            RoundPanel.transform.DOMove(Lasttransform.position, 1f);
            HP_Person.SaveData();

        }
        if (HP_E <= 0)
        {
            Animator_Animy.SetTrigger("Die");
            if (Map_Setting.Number_Max == Map_Setting.Number_now)
            {
                Map_Setting.Number_Max += 1;
                Map_Setting.SaveData();
            }
            int Gold_W = HP_Person.Gold_enemy;
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
            int Rubin_W = HP_Person.Rubin_Enemy;
            HP_Person.Rubin += Rubin_W;
            Rubin.text = Rubin_W.ToString();
            //HP_Person.PointBook += WordButtom.Point_now_Battel;
            //Point.text = WordButtom.Point_now_Battel.ToString();
            int EXP_W = HP_Person.Exp_enemy;
            HP_Person.NowXP += EXP_W;
            Exp.text = EXP_W.ToString();
            //HP_Person.NowXP += 250;
            RoundPanel.SetActive(true);
            GameState = false;
            EndRaund.text = "Вы победили! Так держать!";
            if (HP_Person.NowXP >= HP_Person.NextLVLXP)
            {
                NextLevel.text = "НОВЫЙ УРОВЕНЬ!";
                HP_Person.NextLVL();
            }
            RoundPanel.transform.DOMove(Lasttransform.position, 1f);
            if (HP_Person.Chess_Drop)
            {
                for(int i =0; i< HP_Person.Ches.Length; i++)
                {
                    if (!HP_Person.Ches[i])
                    {
                        HP_Person.Ches[i] = true;
                        break;
                    }
                }
            }
            HP_Person.SaveData();

        }
         //RoundPanel.SetActive(true);
         //GameState = false;
         //RoundPanel.transform.DOMove(Lasttransform.position, 1f);
         //HP_Person.NextLVL();
         //HP_Person.SaveData();
    }
    
}
