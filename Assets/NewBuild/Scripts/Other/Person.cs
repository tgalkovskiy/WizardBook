using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Rendering.PostProcessing;

public class Person : MonoBehaviour
{
    [SerializeField] private WordButtom WordButtom;
    [SerializeField] private CameraEffect CameraEffect;
    [SerializeField] private GameObject text_final = default;
    [SerializeField] private GameObject Last_Pos_text = default;
    [SerializeField] private Text Final_text = default;
    
    [SerializeField] private GameObject[] ActivElement = default;
    [SerializeField] private GameObject RoundPanel = default;
    [SerializeField] private GameObject[] Weapon = default;
    [SerializeField] private GameObject[] EnemyGameObj = default;

    [SerializeField] private GameObject Death_Partical_enemy = default;
    [SerializeField] private GameObject Death_Partical_Pers = default;
    [SerializeField] private GameObject[] Hit;
    
    [SerializeField] private Transform Lasttransform = default;
    
    [SerializeField] private PostProcessVolume _process =default;
    private Vignette _vignette = default;
    
    [SerializeField] private GameConfig gameConfigPerson = default;

    [SerializeField] private Map MapSetting = default;

    [SerializeField] private SaveTutorial _tutorial = default;
    [SerializeField] private GameObject VinTutorial = default;
    [SerializeField] private GameObject LosTutorial = default;

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
    

    [SerializeField] private GameObject Band_Text_Pers;
    [SerializeField] private Animator Band;
    [SerializeField] private GameObject Bamd_text_Eny;

    [SerializeField] private Text Gold;
    [SerializeField] private Text Rubin;
    [SerializeField] private Text Point;
    [SerializeField] private Text Exp;
    [SerializeField] private Text EndRaund;
    
    [SerializeField] private GameObject NextLevel;
    [SerializeField] private GameObject Chees;
    
    private GameObject Enemy;
    private Animator AnimatorEnemy;
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
        gameConfigPerson.LoadData();
        GameState = true;
        HP_G = gameConfigPerson.HP_Gerl + gameConfigPerson.Property_W[1]+ gameConfigPerson.Property_A[1]+gameConfigPerson.Property_O[0];
        HP_E = gameConfigPerson.HP_Enemy;
        DamgeEnemy = gameConfigPerson.Damage;
        Enemy= Instantiate(EnemyGameObj[gameConfigPerson.NumberEnemy]);
        AnimatorEnemy = Enemy.GetComponent<Animator>();
        //EnemyGameObj[HP_Person.NumberEnemy].SetActive(true);
        HP_Gerl.maxValue = HP_G;
        HP_Enemy.maxValue = HP_E;
        DamagePers = gameConfigPerson.Property_W[0] + gameConfigPerson.Property_O[1];   
        Deffence = gameConfigPerson.Property_A[0] + gameConfigPerson.Property_O[2];
        Deffence_Standart_Lvl = Deffence;
        if (gameConfigPerson.Skills[0])
        {
            ActivElement[0].SetActive(true);
            DamagePers +=(int)((DamagePers/100.0f)*5.0f+5*gameConfigPerson.LVL_Skill[0]);
        }
        Weapon[(int)gameConfigPerson.NumberSworld].SetActive(true);
    }

    private void Start()
    {
        HP_Gerl.value = HP_G;
        HP_Gerl_Text.text = ((int)HP_G).ToString() + "/" + (gameConfigPerson.HP_Gerl + gameConfigPerson.Property_W[1] + gameConfigPerson.Property_A[1] + gameConfigPerson.Property_O[0]).ToString();
        HP_Enemy.value = HP_E;
        HP_Enemy_Text.text = ((int)HP_E).ToString() + "/" + (HP_Enemy.maxValue).ToString();
        _process.profile.TryGetSettings(out _vignette);
    }

    
    /*private void FixedUpdate()
    {
        float vin = _vignette.intensity.value;
        if (vin < vin * 10 / 100)
        {
             _vignette.intensity.value += Time.deltaTime;
        }
        else
        {
            _vignette.intensity.value -= Time.deltaTime;
        }
        
    }*/

    private void AttackGerl()
    {
        StartCoroutine(Hit_pers(1));
        GerlAnimator[0].SetTrigger("Attack");
        AnimatorEnemy.SetTrigger("Damage");
        if (WordButtom.Point_now_Battel >= 3 && WordButtom.Point_now_Battel <6)
        {
            HP_E -= DamagePers*1.25f;
            Bamd_text_Eny.GetComponent<TextMesh>().text = ((int)DamagePers).ToString()+" X1.25";
        }
        else if(WordButtom.Point_now_Battel >= 6 && WordButtom.Point_now_Battel<9)
        {
            HP_E -= DamagePers*1.5f;
            Bamd_text_Eny.GetComponent<TextMesh>().text = ((int)DamagePers).ToString()+" X1.5";
        }
        else if(WordButtom.Point_now_Battel >= 9)
        {
            HP_E -= DamagePers*2f;
            Bamd_text_Eny.GetComponent<TextMesh>().text = ((int)DamagePers).ToString()+" X2";
        }
        else
        {
            HP_E -= DamagePers;
            Bamd_text_Eny.GetComponent<TextMesh>().text = ((int)DamagePers).ToString();
        }
        Band.SetTrigger("Eny");
        if (HP_G <= 0 || HP_E <= 0)
        {
            GameState = false;
            EndRound();
        }
    }
    private void AttackEny()
    {
        StartCoroutine(Hit_pers(0));
        AnimatorEnemy.SetTrigger("Attack");
        GerlAnimator[0].SetTrigger("Damage");
        float NowD = DamgeEnemy-Deffence;
        if (NowD > 0)
        {
           HP_G -=DamgeEnemy-Deffence;
           Band_Text_Pers.GetComponent<TextMesh>().text = ((int)DamgeEnemy - Deffence).ToString();
        }
        else
        {
            Band_Text_Pers.GetComponent<TextMesh>().text = 0.ToString();
        }
        if (_vignette.intensity.value < 0.7f)
        {
           _vignette.intensity.value += 0.25f; 
        }
       
        Band.SetTrigger("Pers");
        if (HP_G <= 0 || HP_E <= 0)
        {
            GameState = false;
            EndRound();
        }
    }
    private void EndRound()
    {
        if (HP_G <= 0)
        {
            GerlAnimator[0].SetTrigger("Die");
            text_final.SetActive(false);
            int Gold_Lose = gameConfigPerson.Gold_enemy/10;
            if (gameConfigPerson.Skills[11])
            {
                Gold_Lose += ((Gold_Lose / 100) * (24 + gameConfigPerson.LVL_Skill[11]));
                gameConfigPerson.Gold += Gold_Lose;
            }
            else
            {
                gameConfigPerson.Gold += Gold_Lose;
            }
            Gold.text = Gold_Lose.ToString();
            int Rubin_Lose = 0;
            gameConfigPerson.Rubin += Rubin_Lose;
            gameConfigPerson.Now_BOOK_XP += gameConfigPerson.Exp_enmy_book/3;
            Rubin.text = Rubin_Lose.ToString();
            int EXP_lose = gameConfigPerson.Exp_enemy/10;
            gameConfigPerson.NowXP += EXP_lose;
            Exp.text = EXP_lose.ToString();
            StartCoroutine(Death_Pers());
            EndRaund.text = "В этот раз противник победил..." + "\n" + "Попробуйте улучшить снаряжение и выучить больше волшебных слов!";
            if(gameConfigPerson.NowXP >= gameConfigPerson.NextLVLXP)
            {
                NextLevel.SetActive(true);
                gameConfigPerson.NextLVL();
            }
            gameConfigPerson.SaveData();

        }
        if (HP_E <= 0)
        {
            AnimatorEnemy.SetTrigger("Die");
            MapSetting.enemyNumber[gameConfigPerson.NumberEnemy+1] = true;
            MapSetting.SaveData();
            int Gold_W = gameConfigPerson.Gold_enemy;
            if (gameConfigPerson.Skills[11])
            {
                Gold_W += ((Gold_W / 100) * (24 + gameConfigPerson.LVL_Skill[11]));
                gameConfigPerson.Gold += Gold_W;
            }
            else
            {
                gameConfigPerson.Gold += Gold_W;
            }
            Gold.text = Gold_W.ToString();
            int Rubin_W = gameConfigPerson.Rubin_Enemy;
            gameConfigPerson.Rubin += Rubin_W;
            Rubin.text = Rubin_W.ToString();
            gameConfigPerson.Now_BOOK_XP += gameConfigPerson.Exp_enmy_book;
            int EXP_W = gameConfigPerson.Exp_enemy;
            gameConfigPerson.NowXP += EXP_W;
            Exp.text = EXP_W.ToString();
            StartCoroutine(Death_Enimy());
            EndRaund.text = "Победа, так держать!";
            if (gameConfigPerson.NowXP >= gameConfigPerson.NextLVLXP)
            {
                NextLevel.SetActive(true);
                gameConfigPerson.NextLVL();
            }
            if (gameConfigPerson.Chess_Drop)
            {
                Chees.SetActive(true);
                for(int i =0; i< gameConfigPerson.Ches.Length; i++)
                {
                    if (!gameConfigPerson.Ches[i])
                    {
                        gameConfigPerson.Ches[i] = true;
                        break;
                    }
                }
            }
            gameConfigPerson.SaveData();

        }
         
    }
    
    IEnumerator Death_Enimy()
    {
        CameraEffect.Final();
        yield return new WaitForSeconds(1.5f);
        Death_Partical_enemy.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        RoundPanel.SetActive(true); 
        RoundPanel.transform.DOMove(Lasttransform.position, 1f);
        if (!_tutorial.first_victory)
        {
            VinTutorial.SetActive(true);
            _tutorial.first_victory = true;
            _tutorial.SaveData();
        } 
    }
    IEnumerator Death_Pers()
    {
        CameraEffect.Final();
        yield return new WaitForSeconds(1.5f);
        Death_Partical_Pers.SetActive(true);
        yield return new WaitForSeconds(2f);
        RoundPanel.SetActive(true); 
        RoundPanel.transform.DOMove(Lasttransform.position, 1f);
        if (!_tutorial.first_lose)
        {
            LosTutorial.SetActive(true);
            _tutorial.first_lose = true;
            _tutorial.SaveData();
        } 
    }

    IEnumerator Hit_pers(int Number)
    {
        yield return new WaitForSeconds(0.3f);
        Hit[Number].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Hit[Number].SetActive(false);
        HP_Gerl.value = HP_G;
        HP_Gerl_Text.text = ((int)HP_G).ToString() + "/" + (gameConfigPerson.HP_Gerl + gameConfigPerson.Property_W[1] + gameConfigPerson.Property_A[1] + gameConfigPerson.Property_O[0]).ToString();
        HP_Enemy.value = HP_E;
        HP_Enemy_Text.text = ((int)HP_E).ToString() + "/" + (HP_Enemy.maxValue).ToString();
    }

    /*public void Close_text()
    {
        text_final.transform.DOMove(Last_Pos_text.transform.position, 1f);
    }*/
    
    
}
