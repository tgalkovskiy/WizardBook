using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "HP", menuName = "HP")]
public class HP : ScriptableObject
{
    public class Data
    {
       public int HP;
       public int Attack;
       public int Deff;
       public int LVL;
       public int NextLVL;
       public int XpNow;
       public int Number_Sworld;
       public int Lvl_Book;
       public float Next_LVL_BOOK;
       public float NowBOOK_XP;
       public float NextBOOk_Xp;
       public int Point_Book;
       public bool[] Skills_Deflated;
       public int[] LVL_Slills;
       public float Time;
       public int Gold;
       public int Rubin;
       public int Energy_Max;
       public int Energy_Now;
       public string DateTime;
       public bool Tutorial;
       public bool[] Ches;

    }
    //хп георя
    public int HP_Gerl;
    //хп врага
    public int NumberEnemy = 0;
    public float HP_Spawn_Start = 125f;
    public float HP_Pig_Start = 250f;
    public float HP_Usakula_Start = 400f;
    //параметры игрока
    public int Deffens = 15;
    public int Damage = 30;
    //лвл боевой
    public int LVLPers = 0;
    public int NextLVLXP = 150;
    public int NowXP = 0;
    //лвл книга
    public int LVLBooK = 1;
    public float NextLVL_BOOK_XP = 20;
    public float Now_BOOK_XP = 0;
    public int PointBook = 0;
    //шмот игрока
    public int NumberSworld;
    //словарь
    public string Word;
    //описание скилов
    [HideInInspector]public string[] Description_Skill = new string[12] {"Клинок веры (пассивный): +5% к атаке (+5% за каждый уровень навыка)",
        "Гнев Народа (активный): Навык поджигания на три хода врага, наносит 5% урона от здоровья врага (+3% к урону за каждый уровень навыка)",
        "Лезвие Гааги (пассивный): +25% к любому виду урона (+10% к урону за каждый уровень навыка)", 
        "Сила знаний (активный): Навык минус два(убрать) варианта перевода(перезарядка -1 за каждый уровень навыка)",
        "Здоровое питание (пассивный): +15% к энергии (+5% за каждый уровень навыка)",
        "Медитация (пассивный): +25% к скорости восстановления энергии (+5% за каждый уровень навыка)",
        "Партизанские корни (пассивный): +5% к защите (+3% за каждый уровень навыка)",
        "Сила Воли (активный): Навык блокировки 100% урона от текущего слова (перезарядка -1 за каждый уровень навыка)",
        "Солидарность (пассивный): Блок 25% всего входящего урона (+5% за каждый уровень навыка)",
        "Концентрация (активный): Навык замедления времени вдвое (перезарядка -1 за каждый уровень навыка)",
        "Ясный ум (пассивный): +2 секунды к времени ответа пассивно (+1 секунда за каждый уровень навыка)",
        "Предпринимательский дух (пассивный): +25% к получаемому золоту (+3% за каждый уровень навыка)"
    };
    //скилы
    public bool[] Skills = new bool[12] {false, false , false ,false ,false, false, false, false, false, false, false, false};
    //левел скилов
    public int[] LVL_Skill = new int[12] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    //время раунда
    public float Time_Game = 15;
    //Золото
    public int Gold;
    //рубины
    public int Rubin;
    //Энергия 
    public int Max_Energy;
    public int Now_Energy;
    public bool _Tutorial;
    //time
    public DateTime DateTime;
    public bool[] Ches = new bool[4] {false,false,false,false};

    public void NextLVL()
    {
        if(NowXP>= NextLVLXP)
        {
            NextLVLXP *= 3;
            LVLPers += 1;
            NowXP = 0;
            HP_Gerl += (HP_Gerl / 100) * 15;
            Deffens += 2;
            Max_Energy += 5;
        }
        //if (Now_BOOK_XP >= NextLVL_BOOK_XP)
        //{
        //    NextLVL_BOOK_XP += 2;
        //    LVLBooK += 1;
        //    Now_BOOK_XP = 0;
        //    PointBook += 1;
        //}
    }

    public void SaveData()
    {
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "SaveBOOK.Json");
        Data data = new Data();
        data.HP = HP_Gerl;
        data.Attack = Damage;
        data.Deff = Deffens;
        data.LVL = LVLPers;
        data.NextLVL = NextLVLXP;
        data.XpNow = NowXP;
        data.Number_Sworld = NumberSworld;
        data.Lvl_Book = LVLBooK;
        data.Point_Book = PointBook;
        data.Next_LVL_BOOK = NextLVL_BOOK_XP;
        data.NowBOOK_XP = Now_BOOK_XP;
        data.LVL_Slills = LVL_Skill;
        data.Skills_Deflated = Skills;
        data.Time = Time_Game;
        data.Gold = Gold;
        data.Rubin = Rubin;
        data.Energy_Max = Max_Energy; 
        data.Energy_Now = Now_Energy;
        data.DateTime = DateTime.Now.ToString();
        data.Ches = Ches;
        try
        {
            File.WriteAllText(Path, JsonUtility.ToJson(data));
        }
        catch
        {
            Debug.Log("not Save");
        }
        finally
        {
            Debug.Log("Save Done");
        }
    }

    public void LoadData()
    {
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "SaveBOOK.Json");
        if (File.Exists(Path))
        {
            Data data = new Data();
            data = JsonUtility.FromJson<Data>(File.ReadAllText(Path));
            HP_Gerl = data.HP;
            Damage = data.Attack;
            Deffens = data.Deff;
            LVLPers = data.LVL;
            NextLVLXP = data.NextLVL;
            NowXP = data.XpNow;
            NumberSworld = data.Number_Sworld;
            LVLBooK = data.Lvl_Book;
            PointBook = data.Point_Book;
            NextLVL_BOOK_XP = data.Next_LVL_BOOK;
            Now_BOOK_XP = data.NowBOOK_XP;
            LVL_Skill = data.LVL_Slills;
            Skills = data.Skills_Deflated;
            Time_Game = data.Time;
            Gold = data.Gold;
            Rubin = data.Rubin;
            Max_Energy = data.Energy_Max;
            Now_Energy = data.Energy_Now;
            DateTime = DateTime.Parse(data.DateTime);
            _Tutorial = data.Tutorial;
            Ches = data.Ches;
            Time_Time();
        }
        else
        {
            Debug.Log("No Save");
            HP_Gerl = 200;
            Damage = 20;
            Deffens = 15;
            LVLPers = 1;
            NextLVLXP = 150;
            NowXP = 0;
            NumberSworld = 0;
            LVLBooK = 1;
            PointBook = 0;
            NextLVL_BOOK_XP = 20;
            Now_BOOK_XP = 0;
            Skills = new bool[12] { false, false, false, false, false, false, false, false, false, false, false, false };
            LVL_Skill = new int[12] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            Time_Game = 15;
            Gold = 1000;
            Rubin = 100;
            Max_Energy = 15;
            Now_Energy = 100;
            DateTime = DateTime.Now;
            _Tutorial = true;
            Ches = new bool[4]{ false, false, false, false };
        } 
        

    }
    public void Time_Time()
    {
        if(DateTime.Day < DateTime.Now.Day)
        {
            Now_Energy = Max_Energy;
        }
        if(DateTime.Hour < DateTime.Now.Hour && Now_Energy < Max_Energy)
        {
            int Time = (DateTime.Now.Hour - DateTime.Hour)*LVL_Skill[5];
            Now_Energy += Time;
        }
    }

}
