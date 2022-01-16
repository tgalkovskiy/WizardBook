using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManeger : MonoBehaviour
{
    [SerializeField] private Animator PersAnimator;
    //общие поля
    [SerializeField] private GameConfig gameConfigSKills = default;
    [SerializeField] private Person Person;
    [SerializeField] private WordButtom WordButtom = default;

    //геймобджекты и кнопки
    [SerializeField] private GameObject Fire_Enimy = default;
    [SerializeField] private GameObject FireErln = default;

    [SerializeField] private GameObject Shild =default;

    [SerializeField] private GameObject Time_shift = default;

    [SerializeField] private GameObject _Watter_skill = default;

    [SerializeField] private AudioSource Magic = default;
    [SerializeField] private AudioClip[] Magic_Clip = default;
    
    [SerializeField] private GameObject Buttom_Skil_2 = default;
    [SerializeField] private GameObject Buttom_Skill_7 = default;
    [SerializeField] private GameObject Buttom_Skill_10 = default;
    [SerializeField] private GameObject Buttom_Skill_3 = default;
    [SerializeField] private Button[] Skill_buton = default;
    
    //поджог
    [SerializeField] private Sprite[] Arson_Sprite = default;
    public static Image Buttom_Arson_Image;

    private int EndArson =0;
    private int CooldownArson = 0;
    private float ArsonDamege;

    //защита скил
    [SerializeField] private Sprite[] Deffence_Sprite = default;
    public  static Image Buttom_Deffence;

    private int End_Deff = 0;
    public static int Cooldown_Deff = 0;

    //замедление скилл
    [SerializeField] private Sprite[] Time_stop = default;
    public static Image Buttom_Time_Stop;

    private int EndTime =0;
    public static int CoolDown_Time = 0;


    [SerializeField] private Sprite[] Watter_skill = default;
    public static Image Buttom_Watter;

    private int End_Watter =0;
    public static int Cooldown_Watter = 0;
    private void Awake()
    {
        Cooldown_Deff = 0;
        CoolDown_Time = 0;
        Cooldown_Watter = 0;
        //если активен второй сиклл
        if (gameConfigSKills.Skills[1])
        {
            //компоненты и кнопка для данного скила
            Buttom_Arson_Image = Skill_buton[0].GetComponent<Image>();
            Buttom_Skil_2.SetActive(true);
            ArsonDamege = (Person.HP_E / 100.0f) * (2f+1*gameConfigSKills.LVL_Skill[1]);
        }
        //если активне 3 скил
        if (gameConfigSKills.Skills[2])
        {
            //увелчиение общего урона
            Person.DamagePers += (Person.DamagePers / 100.0f) * (25.0f+ gameConfigSKills.LVL_Skill[2]);
            //увеличение силы поджога
            ArsonDamege += (ArsonDamege / 100.0f) * (25.0f+10*gameConfigSKills.LVL_Skill[2]);
        }
        //если активне 7 скилл
        if (gameConfigSKills.Skills[6])
        {
            //прирост к защите 
            Person.Deffence += (Person.Deffence / 100.0f) * (5.0f+ gameConfigSKills.LVL_Skill[6]);
        }
        //если активне 8 скилл
        if (gameConfigSKills.Skills[7])
        {
            //компоненты и кнопка для данного скилла
            Buttom_Deffence = Skill_buton[1].GetComponent<Image>();
            Buttom_Skill_7.SetActive(true);
        }
        //скил на увеличение времени хода 11 скил 
        if (gameConfigSKills.Skills[10])
        {
            WordButtom.Deff_Timer += 2+ gameConfigSKills.LVL_Skill[9];
        }
        //скилл замедления времени
        if (gameConfigSKills.Skills[9])
        {
            Buttom_Time_Stop = Skill_buton[2].GetComponent<Image>();
            Buttom_Skill_10.SetActive(true);
        }
        if (gameConfigSKills.Skills[3])
        {
            Buttom_Watter = Skill_buton[3].GetComponent<Image>();
            Buttom_Skill_3.SetActive(true);
        }

    }
    private void Update()
    {
        //если активне 2 скилл
        if (gameConfigSKills.Skills[1])
        {
            if(WordButtom.Moves == EndArson)
            {
                Fire_Enimy.SetActive(false);
                EventMeneger.GerlAttack1 -= Arson;
                EventMeneger.EnemyAttack1 -= Arson;
            }
            if(WordButtom.Moves == CooldownArson)
            {
                CooldownArson = 0;
                //Buttom_Arson_Image.sprite = Arson_Sprite[0];
            }
        }
        //если активне 8 скилл
        if (gameConfigSKills.Skills[7])
        {
            if(WordButtom.Moves == End_Deff)
            {
                Person.Deffence = Person.Deffence_Standart_Lvl;
                Shild.SetActive(false);
            }
            if(WordButtom.Moves == Cooldown_Deff)
            {
                Cooldown_Deff = 0;
                //Buttom_Deffence.sprite = Deffence_Sprite[0];
            }
        }
        //если 9 скилл
        if (gameConfigSKills.Skills[9])
        {
            if (WordButtom.Moves == EndTime)
            {
                Time.timeScale = 1;
                Time_shift.SetActive(false);
            }
            if(WordButtom.Moves == CoolDown_Time)
            {
                CoolDown_Time = 0;
                //Buttom_Time_Stop.sprite = Time_stop[0];
            }
        }
        //если 4 скилл
        if (gameConfigSKills.Skills[3])
        {
            if(WordButtom.Moves == End_Watter)
            {
                //Cooldown_Watter = 0;
                _Watter_skill.SetActive(false);
            }
            if(WordButtom.Moves == Cooldown_Watter)
            {
                Cooldown_Watter = 0;
                //Buttom_Watter.sprite = Watter_skill[0];
            }
        }
    }
    public void Activ_Fire_Skill_2()
    {
        if(CooldownArson == 0)
        {
            PersAnimator.SetTrigger("Arson");
            StartCoroutine(_FireErln());
            Magic.PlayOneShot(Magic_Clip[0]);
            Fire_Enimy.SetActive(true);
            EventMeneger.GerlAttack1 += Arson;
            EventMeneger.EnemyAttack1 += Arson;
            EndArson = WordButtom.Moves + 3;
            CooldownArson = WordButtom.Moves + 6;
            Buttom_Arson_Image.fillAmount = 0;
            //Buttom_Arson_Image.sprite = Arson_Sprite[1];
        }
       
    }
    public void Activ_Floor_Skill_7()
    {
        if(Cooldown_Deff == 0)
        {
            PersAnimator.SetTrigger("Shild");
            Magic.PlayOneShot(Magic_Clip[1]);
            Shild.SetActive(true);
            //Buttom_Deffence.sprite = Deffence_Sprite[1];
            Person.Deffence = 10000000;
            Buttom_Deffence.fillAmount = 0;
            Cooldown_Deff = WordButtom.Moves + 6-gameConfigSKills.LVL_Skill[7];
            End_Deff = WordButtom.Moves + 1;
        }
    }
    public void Activ_Time_Skill_10()
    {
        if(CoolDown_Time == 0)
        {
            Time_shift.SetActive(true);
            Magic.PlayOneShot(Magic_Clip[2]);
            //Buttom_Time_Stop.sprite = Time_stop[1];
            Time.timeScale = 0.5f;
            CoolDown_Time = WordButtom.Moves + 6 - gameConfigSKills.LVL_Skill[10];
            Buttom_Time_Stop.fillAmount = 0;
            EndTime = WordButtom.Moves + 1;
        }
    }
    public void Activ_Watter_Skill_3()
    {
        if(Cooldown_Watter == 0)
        {
            //Buttom_Watter.sprite = Watter_skill[1];
            Magic.PlayOneShot(Magic_Clip[3]);
            _Watter_skill.SetActive(true);
            WordButtom.Delete_Word();
            Buttom_Watter.fillAmount = 0;
            Cooldown_Watter = WordButtom.Moves + 6 - gameConfigSKills.LVL_Skill[3];
            End_Watter = WordButtom.Moves + 1;
        }
    }
    public void Arson()
    {
        Person.HP_E -= ArsonDamege;
    }

    IEnumerator _FireErln()
    {
        yield return new WaitForSeconds(0.4f);
        FireErln.SetActive(true);
        yield return new WaitForSeconds(1f);
        FireErln.SetActive(false);
    }
}
