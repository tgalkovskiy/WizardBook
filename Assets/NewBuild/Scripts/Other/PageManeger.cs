using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PageManeger : MonoBehaviour
{
    [SerializeField] private HP StatPers;

    [SerializeField] private SaveTutorial _tutorial = default;
    [SerializeField] private GameObject First_tutorial = default;
    
    
    [SerializeField] private GameObject Page1 =default;
    [SerializeField] private GameObject Page2 = default;
    [SerializeField] private GameObject Page3 = default;
    [SerializeField] private GameObject Page4 = default;
    
    [SerializeField] private GameObject NextLVLMainPage = default;
    [SerializeField] private GameObject NextLVlBG = default;
    
    [SerializeField] private Text Gold = default;
    [SerializeField] private Text Rubin = default;
    [SerializeField] private Text Energy = default;
    private int ChoisKnife;
    private int Cost_now_Item;
    private int Attack_Chois;
    private void Awake()
    {
        StatPers.LoadData();
        _tutorial.LoadData();
        if (!_tutorial.first_tutorial)
        {
            First_tutorial.SetActive(true);
            _tutorial.first_tutorial = true;
            _tutorial.SaveData();
        }
    }
    public void BOOK()
    {
        Page1.SetActive(false);
        Page3.SetActive(false);
        Page2.SetActive(true);
        Page4.SetActive(false);
        
    }
    public void EQUIP()
    {
        Page2.SetActive(false);
        Page1.SetActive(false);
        Page4.SetActive(false);
        Page3.SetActive(true);
       

    }
    public void MainPage()
    {
        Page1.SetActive(true);
        /*var A_BG = BG_image.color;
        A_BG.a = 1;
        BG_image.color = A_BG;*/
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
        /*var A_BG = BG_image.color;
        A_BG.a = 1;
        BG_image.color = A_BG;*/

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
