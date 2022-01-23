using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MenuLVLGIU : MonoBehaviour
{
    [SerializeField] private GameConfig stat = default;
    [SerializeField] private Text Lvl_Text = default;
    [SerializeField] private Image LVL_Figth = default;
    [SerializeField] private Text LvlBook = default;
    [SerializeField] private Image LVL_BOOK = default;
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
    public GameObject upBookPanel;
    public Button upBook;
    //[SerializeField] private Text NextLVL_Book;
    private bool Skill;
    private int NumberSkill;
    private int Cost_Now_Skill;
 
    private void Awake()
    {
        LVL_Figth.fillAmount = (float)stat.NowXP/stat.NextLVLXP;
        LVL_BOOK.fillAmount = stat.Now_BOOK_XP/stat.NextLVL_BOOK_XP;
        upBook.onClick.AddListener(LVL_Up_Book);
        //LVL_BOOK.value = stat.Now_BOOK_XP;
        Lvl_Text.text = stat.LVLPers.ToString();
        LvlBook.text = stat.LVLBooK.ToString();
        PointBook.text = stat.PointBook.ToString();
        Discription_Skill_Text.text = "";
        Skill = false;
        for(int i =0; i<Button_Skill.Length; i++)
        {
            if (stat.Skills[i])
            {
                Button_Skill[i].GetComponent<Image>().sprite = Activ_Button[i];
            }
        }
        if (stat.Now_BOOK_XP >= stat.NextLVL_BOOK_XP)
        {
            //NextLVL_Book.text = "НОВЫЙ УРОВЕНЬ!";
        }
        else
        {
            //NextLVL_Book.text = "";
        }
}

    public void SliilButtom(int NumberButtom)
    {
        Discription_Skill_Text.text = $"ПОТРАТИТЬ {Cost_Now_Skill} ЭФИРА НА НАВЫК?";
        NumberSkill = NumberButtom;
        Skill = true;
        Window_Discription.SetActive(true);
        if (stat.Skills[NumberSkill])
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
        if(stat.PointBook >= Cost_Now_Skill)
        {
            if(Skill && stat.Skills[NumberSkill] != true)
            {
                stat.Skills[NumberSkill] = true;
                stat.PointBook -= Cost_Now_Skill;
                PointBook.text = stat.PointBook.ToString();
                Button_Skill[NumberSkill].GetComponent<Image>().sprite = Activ_Button[NumberSkill];
                if (NumberSkill == 4)
                {
                    stat.Max_Energy += (int)(((float)stat.Max_Energy / 100.00) * 15.00 + 5* stat.LVL_Skill[4]);
                }
                stat.SaveData();
                Window_Discription.SetActive(false);
            }
            else if(Skill && stat.Skills[NumberSkill] && stat.LVL_Skill[NumberSkill] < stat.LVLBooK+1)
            {
                stat.LVL_Skill[NumberSkill] += 1;
                stat.PointBook -= Cost_Now_Skill;
                PointBook.text = stat.PointBook.ToString();
                if (NumberSkill == 4)
                {
                    stat.Max_Energy += (int)(((float)stat.Max_Energy / 100.00) * 15.00 + 5 * stat.LVL_Skill[4]);
                }
                stat.SaveData();
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
    public void LVL_Up_Book()
    {
        if(stat.Now_BOOK_XP < stat.NextLVL_BOOK_XP) return;
        upBookPanel.SetActive(true);
        if (stat.LVLBooK == 1)
        {
            Cost_Book.text = "Цена: "+ 1000 + " монет";
        }
        else
        {
            Cost_Book.text = "Цена: " + ((stat.LVLBooK * 1000) + 1000).ToString() +" монет";
        }
        
    }
    public void Chois_Book()
    {
        int money;
        if (stat.LVLBooK == 1)
        {
            money = 1000;
        }
        else
        {
            money = (stat.LVLBooK * 1000) + 1000;
        }
        if (money <= stat.Gold)
        {
            if(stat.Now_BOOK_XP >= stat.NextLVL_BOOK_XP)
            {
                stat.PointBook += stat.LVLBooK;
                stat.LVLBooK += 1;
                stat.NextLVL_BOOK_XP *=1.8f;
                stat.Now_BOOK_XP = 0;
                stat.Gold -= money;
                LvlBook.text = stat.LVLBooK.ToString();
                PointBook.text = stat.PointBook.ToString();
                LVL_BOOK.fillAmount = stat.Now_BOOK_XP/stat.NextLVL_BOOK_XP;
                Uimanager.ChangeMainResurses(stat, MainResurses.Instance.gold, MainResurses.Instance.energy, MainResurses.Instance.rubin);
                Uimanager.CloseWindow(upBookPanel);
                stat.SaveData();
            }
        }
        else
        {
            Uimanager.OpenWindow(No_money);
        }
        
    }
    
}
