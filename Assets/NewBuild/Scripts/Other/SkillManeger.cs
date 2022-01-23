using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManeger : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
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
    public GameObject particalFirstSkill;
    
    //поджог
    [SerializeField] private Sprite[] Arson_Sprite = default;
    public static Image Buttom_Arson_Image;

    private int EndArson =0;
    private int CooldownArson = 0;
    private int ArsonDamege;

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
        if (gameConfigSKills.Skills[0])
        {
            particalFirstSkill.SetActive(true);
        }
        //если активен второй сиклл
        if (gameConfigSKills.Skills[1])
        {
            //компоненты и кнопка для данного скила
            Buttom_Arson_Image = Skill_buton[0].GetComponent<Image>();
            Buttom_Skil_2.SetActive(true);
            ArsonDamege = (Person.hpEnemyInBattle / 100) * (2+1*gameConfigSKills.LVL_Skill[1]);
        }
        //если активне 3 скил
        if (gameConfigSKills.Skills[2])
        {
            //увелчиение общего урона
            Person.damagePlayerInBattle += (Person.damagePlayerInBattle / 100) * (25+ gameConfigSKills.LVL_Skill[2]);
            //увеличение силы поджога
            ArsonDamege += (ArsonDamege / 100) * (25+10*gameConfigSKills.LVL_Skill[2]);
        }
        //если активне 7 скилл
        if (gameConfigSKills.Skills[6])
        {
            //прирост к защите 
            Person.playerDefence += (Person.playerDefence / 100) * (5+ gameConfigSKills.LVL_Skill[6]);
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
            WordButtom.timerInRaund += 2+ gameConfigSKills.LVL_Skill[9];
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
        UpdateCooldown();
    }
    public void UpdateCooldown()
    {
        //если активне 2 скилл
        if (gameConfigSKills.Skills[1])
        {
            if(WordButtom.Moves >= EndArson)
            {
                Fire_Enimy.SetActive(false);
                EventManager.playerAction -= Arson;
                EventManager.enemyAction -= Arson;
            }
            if(WordButtom.Moves >= CooldownArson)
            {
                CooldownArson = 0;
            }
        }
        //если активне 8 скилл
        if (gameConfigSKills.Skills[7])
        {
            if(WordButtom.Moves >= End_Deff)
            {
                Person.playerDefence = Person.Deffence_Standart_Lvl;
                Shild.SetActive(false);
            }
            if(WordButtom.Moves >= Cooldown_Deff)
            {
                Cooldown_Deff = 0;
            }
        }
        //если 9 скилл
        if (gameConfigSKills.Skills[9])
        {
            if (WordButtom.Moves >= EndTime)
            {
                Time.timeScale = 1;
                Time_shift.SetActive(false);
            }
            if(WordButtom.Moves >= CoolDown_Time)
            {
                CoolDown_Time = 0;
            }
        }
        //если 4 скилл
        if (gameConfigSKills.Skills[3])
        {
            if(WordButtom.Moves >= End_Watter)
            {
                //Cooldown_Watter = 0;
                _Watter_skill.SetActive(false);
            }
            if(WordButtom.Moves >= Cooldown_Watter)
            {
                Cooldown_Watter = 0;
            }
        }
    }
    public void Activ_Fire_Skill_2()
    {
        if(CooldownArson == 0)
        {
            StartCoroutine(ExecuteArson());
        }
       
    }
    public void Activ_Floor_Skill_7()
    {
        if(Cooldown_Deff == 0)
        {
            StartCoroutine(ExecuteShield());
        }
    }
    public void Activ_Time_Skill_10()
    {
        if (CoolDown_Time != 0) return;
        playerAnimator.SetTrigger("StopTime");
        Magic.PlayOneShot(Magic_Clip[2]);
        Time.timeScale = 0.5f;
        CoolDown_Time = WordButtom.Moves + 6 - gameConfigSKills.LVL_Skill[10];
        Buttom_Time_Stop.fillAmount = 0;
        EndTime = WordButtom.Moves + 1;
    }
    public void Activ_Watter_Skill_3()
    {
        if (Cooldown_Watter != 0) return;
        playerAnimator.SetTrigger("DeleteWord");
        Magic.PlayOneShot(Magic_Clip[3]);
        _Watter_skill.SetActive(true);
        WordButtom.Delete_Word();
        Buttom_Watter.fillAmount = 0;
        Cooldown_Watter = WordButtom.Moves + 6 - gameConfigSKills.LVL_Skill[3];
        End_Watter = WordButtom.Moves + 1;
    }
    public void Arson()
    {
        Person.hpEnemyInBattle -= ArsonDamege;
    }

    IEnumerator _FireErln()
    {
        yield return new WaitForSeconds(0.4f);
        FireErln.SetActive(true);
        yield return new WaitForSeconds(1f);
        FireErln.SetActive(false);
    }

    private IEnumerator ExecuteShield()
    {
        playerAnimator.SetTrigger("Shild");
        Magic.PlayOneShot(Magic_Clip[1]);
        Buttom_Deffence.fillAmount = 0;
        Person.playerDefence = 10000000;
        Cooldown_Deff = WordButtom.Moves + 6-gameConfigSKills.LVL_Skill[7];
        End_Deff = WordButtom.Moves + 1;
        yield return new WaitForSeconds(1);
        Shild.SetActive(true);
    }
    private IEnumerator ExecuteArson()
    {
        playerAnimator.SetTrigger("Arson");
        Magic.PlayOneShot(Magic_Clip[0]);
        Buttom_Arson_Image.fillAmount = 0;
        EndArson = WordButtom.Moves + 3;
        CooldownArson = WordButtom.Moves + 6;
        yield return new WaitForSeconds(2);
        Fire_Enimy.SetActive(true);
        EventManager.playerAction += Arson;
        EventManager.enemyAction += Arson;
    } 
}
