using System;
using System.IO;
using UnityEngine;

public class Data
{
       public int HP;
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
       public int Ches;

}
[CreateAssetMenu(fileName = "GameConfig", menuName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    
    public int hpPerson;
    public int damagePerson;
    public int defencePerson;
    public int resitPotion;
    public int resitCold;
    public int resitFire;
    //лвл боевой
    public int LVLPers = 0;
    public int NextLVLXP = 150;
    public int NowXP = 0;
    //лвл книга
    public int LVLBooK = 1;
    public float NextLVL_BOOK_XP = 40;
    public float Now_BOOK_XP = 0;
    public int PointBook = 0;
    //шмот игрока
    public int NumberSworld;
    //описание скилов
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
    
    //time
    public DateTime DateTime;
    public int ches = 0;
    
    public void NextLVL()
    {
        if(NowXP>= NextLVLXP)
        {
            NextLVLXP *= 4;
            LVLPers += 1;
            NowXP = 0;
            hpPerson += (hpPerson / 100) * 25;
            Max_Energy += 5;
        }
    }

    public void SaveData()
    {
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "SaveBOOK.Json");
        Data data = new Data();
        data.HP = hpPerson;
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
        data.Ches = ches;
        try
        {
            File.WriteAllText(Path, JsonUtility.ToJson(data));
        }
        catch
        {
            //Debug.Log("not Save");
        }
        finally
        {
            //Debug.Log("Save Done");
        }
    }

    public void LoadData()
    {
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "SaveBOOK.Json");
        if (File.Exists(Path))
        {
            Data data = new Data();
            data = JsonUtility.FromJson<Data>(File.ReadAllText(Path));
            hpPerson = data.HP;
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
            ches = data.Ches;
            Time_Time();
        }
        else
        {
            Debug.Log("No Save");
            hpPerson = 200;
            LVLPers = 1;
            NextLVLXP = 300;
            NowXP = 0;
            NumberSworld = 0;
            LVLBooK = 1;
            PointBook = 0;
            NextLVL_BOOK_XP = 300;
            Now_BOOK_XP = 0;
            Skills = new bool[12] { false, false, false, false, false, false, false, false, false, false, false, false };
            LVL_Skill = new int[12] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            Time_Game = 15;
            Gold = 2000;
            Rubin = 20;
            Max_Energy = 15;
            Now_Energy = 50;
            DateTime = DateTime.Now;
            ches = 0;
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
