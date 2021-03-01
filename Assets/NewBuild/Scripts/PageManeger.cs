using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PageManeger : MonoBehaviour
{
    [SerializeField] private HP StatPers;
    //[SerializeField] private GameObject BG = default;
    [SerializeField] private Image BG_image;
    [SerializeField] private GameObject Page1 =default;
    [SerializeField] private GameObject Page2 = default;
    [SerializeField] private GameObject Page3 = default;
    [SerializeField] private GameObject Page4 = default;
    [SerializeField] private GameObject Window_Quip = default;
    [SerializeField] private GameObject Equip_GameObj = default;
    [SerializeField] private GameObject NO_money = default;
    [SerializeField] private GameObject[] Weapon = default;
    [SerializeField] private GameObject NextLVLMainPage = default;
    [SerializeField] private GameObject NextLVlBG = default;
    [SerializeField] private Text AttackPers = default;
    [SerializeField] private Text DeffencePers = default;
    [SerializeField] private Text Discription_Item = default;
    [SerializeField] private Text Type_Item = default;
    [SerializeField] private Text Gold = default;
    [SerializeField] private Text Rubin = default;
    [SerializeField] private Text Energy = default;
    private int ChoisKnife;
    private int Cost_now_Item;
    private int Attack_Chois;
    private void Awake()
    {
        StatPers.LoadData();
    }
    public void BOOK()
    {
        Page1.SetActive(false);
        Page3.SetActive(false);
        Page2.SetActive(true);
        var A_BG = BG_image.color;
        A_BG.a = 1;
        BG_image.color = A_BG;
        Page4.SetActive(false);
        
    }
    public void EQUIP()
    {
        Page2.SetActive(false);
        Page1.SetActive(false);
        Page4.SetActive(false);
        var A_BG = BG_image.color;
        A_BG.a = 0;
        BG_image.color = A_BG;
        Page3.SetActive(true);
        AttackPers.text = "Атака: " + StatPers.Damage_Sword[(int)StatPers.NumberSworld].ToString();
        DeffencePers.text = "Защита: " + StatPers.Deffens.ToString();
        Weapon[(int)StatPers.NumberSworld].SetActive(true);

    }
    public void MainPage()
    {
        Page1.SetActive(true);
        var A_BG = BG_image.color;
        A_BG.a = 1;
        BG_image.color = A_BG;
        Page2.SetActive(false);
        Page3.SetActive(false);
        Page4.SetActive(false);
    }

    public void Shop()
    {
        
        Page1.SetActive(false);
        Page2.SetActive(false);
        Page3.SetActive(false);
        Page4.SetActive(true);
        var A_BG = BG_image.color;
        A_BG.a = 1;
        BG_image.color = A_BG;

    }
    public void Cost_Now_Item(int Cost)
    {
        Cost_now_Item = Cost;
    }
    public void Attack(int Attack)
    {
        Attack_Chois = Attack;
    }
    public void Choisknife(int NumberKnife)
    {
        ChoisKnife = NumberKnife;
        if (StatPers.By_Sword[NumberKnife])
        {
            Discription_Item.text = "Aтака " + StatPers.Damage_Sword[NumberKnife] + "\n" + "Уровень предмета " + StatPers.LVl_Sword[NumberKnife] + "\n" + "Цена " + Cost_now_Item/10;
            Cost_now_Item /= 10;
            Type_Item.text = "Улучшить?";
            Equip_GameObj.SetActive(true);
        }
        else
        {
            Discription_Item.text = "Aтака "+ StatPers.Damage_Sword[NumberKnife] + "\n" + "Уровень предмета " + StatPers.LVl_Sword[NumberKnife] + "\n" + "Цена " + Cost_now_Item;
            Type_Item.text = "Купить?";
            Equip_GameObj.SetActive(false);
        }
        Window_Quip.SetActive(true);
    }
    public void Equip()
    {
        if(StatPers.Gold>= Cost_now_Item)
        {
            if (!StatPers.By_Sword[ChoisKnife])
            {
                StatPers.By_Sword[ChoisKnife] = true;
                StatPers.Gold -= Cost_now_Item;
                Discription_Item.text = "Aтака " + StatPers.Damage_Sword[ChoisKnife] + "\n" + "Уровень предмета " + StatPers.LVl_Sword[ChoisKnife] + "\n" + "Цена " + Cost_now_Item;
                Equip_GameObj.SetActive(true);
            }
            else
            {
                StatPers.Damage_Sword[ChoisKnife] += 2;
                StatPers.Gold -= Cost_now_Item;
                Discription_Item.text = "Aтака " + StatPers.Damage_Sword[ChoisKnife] + "\n" + "Уровень предмета " + StatPers.LVl_Sword[ChoisKnife] + "\n" + "Цена " + Cost_now_Item;
            }
        StatPers.SaveData();
        }
        else
        {
            NO_money.SetActive(true);
        }
    }
    public void Select()
    {
        StatPers.NumberSworld = ChoisKnife;
        AttackPers.text = "Атака: " + StatPers.Damage_Sword[ChoisKnife];
        DeffencePers.text = "Защита: " + StatPers.Deffens.ToString();
        for(int i =0; i< Weapon.Length; i++)
        {
            Weapon[i].SetActive(false);
        }
        Weapon[(int)StatPers.NumberSworld].SetActive(true);
        StatPers.SaveData();
        Window_Quip.SetActive(false);

    }
    private void Update()
    {
        Gold.text = StatPers.Gold.ToString();
        Rubin.text = StatPers.Rubin.ToString();
        Energy.text = StatPers.Now_Energy.ToString() + "/" + StatPers.Max_Energy.ToString();
        if(StatPers.Now_BOOK_XP >= StatPers.NextLVL_BOOK_XP)
        {
            NextLVLMainPage.SetActive(true);
            NextLVlBG.SetActive(true);
        }
        else
        {
            NextLVLMainPage.SetActive(false);
            NextLVlBG.SetActive(false);
        }
    }


    public void Enrgy_Plus()
    {
        StatPers.Now_Energy += 5;
    }
}
