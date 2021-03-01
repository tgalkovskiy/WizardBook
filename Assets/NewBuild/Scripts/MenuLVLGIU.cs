using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLVLGIU : MonoBehaviour
{
    [SerializeField] private HP HP_PERS = default;
    [SerializeField] private Text Lvl_Text = default;
    [SerializeField] private Slider LVL_Figth = default;
    [SerializeField] private Text LvlBook = default;
    [SerializeField] private Slider LVL_BOOK = default;
    [SerializeField] private Text PointBook  = default;
    [SerializeField] private Text Discription_Skill_Text = default;
    [SerializeField] private Button[] Button_Skill = default;
    [SerializeField] private Sprite[] Activ_Button = default;
    [SerializeField] private GameObject Window_Discription = default;
    [SerializeField] private GameObject NO_Point_Book;
    [SerializeField] private GameObject No_money = default;
    [SerializeField] private GameObject Need_Up_Book = default;
    [SerializeField] private Text Chois;
    [SerializeField] private Text Cost_Book;
    [SerializeField] private Text NextLVL_Book;
    private bool Skill;
    private int NumberSkill;
    private int Cost_Now_Skill;
 
    private void Awake()
    {
        LVL_Figth.maxValue = HP_PERS.NextLVLXP;
        LVL_Figth.value = HP_PERS.NowXP;
        LVL_BOOK.maxValue = HP_PERS.NextLVL_BOOK_XP;
        LVL_BOOK.value = HP_PERS.Now_BOOK_XP;
        Lvl_Text.text = HP_PERS.LVLPers.ToString();
        LvlBook.text = HP_PERS.LVLBooK.ToString();
        PointBook.text = HP_PERS.PointBook.ToString();
        Discription_Skill_Text.text = "";
        Skill = false;
        for(int i =0; i<Button_Skill.Length; i++)
        {
            if (HP_PERS.Skills[i])
            {
                Button_Skill[i].GetComponent<Image>().sprite = Activ_Button[i];
            }
        }
        if (HP_PERS.Now_BOOK_XP >= HP_PERS.NextLVL_BOOK_XP)
        {
            NextLVL_Book.text = "Можно улучшить книгу слов, и получить эфир!";
        }
        else
        {
            NextLVL_Book.text = "";
        }
}

    public void SliilButtom(int NumberButtom)
    {
        Discription_Skill_Text.text = HP_PERS.Description_Skill[NumberButtom] + "\n" + "Уровень " + HP_PERS.LVL_Skill[NumberButtom]+"\n"+"Цена "+Cost_Now_Skill;
        NumberSkill = NumberButtom;
        Skill = true;
        Window_Discription.SetActive(true);
        if (HP_PERS.Skills[NumberSkill])
        {
            Chois.text = "Улучшить?";
        }
        else
        {
            Chois.text = "Открыть?";
        }
       
    }
    public void Cost_Skill(int Cost)
    {
        Cost_Now_Skill = Cost;
    }
    public void ChoisSkills()
    {
        if(HP_PERS.PointBook >= Cost_Now_Skill)
        {
            if(Skill && HP_PERS.Skills[NumberSkill] != true)
            {
                HP_PERS.Skills[NumberSkill] = true;
                HP_PERS.PointBook -= Cost_Now_Skill;
                PointBook.text = HP_PERS.PointBook.ToString();
                Button_Skill[NumberSkill].GetComponent<Image>().sprite = Activ_Button[NumberSkill];
                if (NumberSkill == 4)
                {
                    HP_PERS.Max_Energy += (int)(((float)HP_PERS.Max_Energy / 100.00) * 15.00 * HP_PERS.LVL_Skill[4]);
                }
                HP_PERS.SaveData();
                Window_Discription.SetActive(false);
            }
            else if(Skill && HP_PERS.Skills[NumberSkill] && HP_PERS.LVL_Skill[NumberSkill] < HP_PERS.LVLBooK+1)
            {
                HP_PERS.LVL_Skill[NumberSkill] += 1;
                HP_PERS.PointBook -= Cost_Now_Skill;
                PointBook.text = HP_PERS.PointBook.ToString();
                if (NumberSkill == 4)
                {
                    HP_PERS.Max_Energy += (int)(((float)HP_PERS.Max_Energy / 100.00) * 15.00 * HP_PERS.LVL_Skill[4]);
                }
                HP_PERS.SaveData();
                Window_Discription.SetActive(false);
            }
            else
            {
                Need_Up_Book.SetActive(true);
            }
        }
        else
        {
            NO_Point_Book.SetActive(true);
        }
       
        
    }
    public void Bakc(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
    public void LVL_Up_Book(GameObject gameObject)
    {
        gameObject.SetActive(true);
        if (HP_PERS.LVLBooK == 0)
        {
            Cost_Book.text = "Цена: "+ 600 + " монет";
        }
        else
        {
            Cost_Book.text = "Цена: " + ((HP_PERS.LVLBooK * 1000) + 1000).ToString() +" монет";
        }
        
    }
    public void Chois_Book(GameObject gameObject)
    {
        int money;
        if (HP_PERS.LVLBooK == 0)
        {
            money = 600;
        }
        else
        {
            money = (HP_PERS.LVLBooK * 1000) + 1000;
        }
        if (money <= HP_PERS.Gold)
        {
            Debug.Log(3);
            if(HP_PERS.Now_BOOK_XP >= HP_PERS.NextLVL_BOOK_XP)
            {
                HP_PERS.LVLBooK += 1;
                HP_PERS.PointBook += 1;
                HP_PERS.NextLVL_BOOK_XP += 10;
                HP_PERS.Now_BOOK_XP = 0;
                HP_PERS.Gold -= money;
                LvlBook.text = HP_PERS.LVLBooK.ToString();
                PointBook.text = HP_PERS.PointBook.ToString();
                LVL_BOOK.maxValue = HP_PERS.NextLVL_BOOK_XP;
                LVL_BOOK.value = HP_PERS.Now_BOOK_XP;
                NextLVL_Book.text = "";
                gameObject.SetActive(false);
                HP_PERS.SaveData();
            }
        }
        else
        {
            No_money.SetActive(true);
        }
        
    }

    public void Open_window(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
}
