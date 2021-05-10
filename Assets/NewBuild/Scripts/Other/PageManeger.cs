using System;
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
    [SerializeField] private GameObject[] Buttoms = default;
    
    [SerializeField] private GameObject NextLVLMainPage = default;
    [SerializeField] private GameObject NextLVlBG = default;
    [SerializeField] private GameObject Chess = default;

    [SerializeField] private Text Text_book = default;
    
    [SerializeField] private Text Gold = default;
    [SerializeField] private Text Rubin = default;
    [SerializeField] private Text Energy = default;

    [SerializeField] private Sprite[] _imagesMenu = default;
    [SerializeField] private Image _imagesBook = default;
    [SerializeField] private Image _imagesUp = default;
    [SerializeField] private Image _imagesDown = default;

    private void OnEnable()
    {
        Vizual();
    }

    public void Vizual()
    {
        if (StatPers.LVLBooK < 3)
        {
            _imagesBook.sprite = _imagesMenu[0];
            _imagesUp.sprite = _imagesMenu[1];
            _imagesDown.sprite = _imagesMenu[1];
            Text_book.text = "Ученик Мага";
        }

        if (StatPers.LVLBooK >= 3 && StatPers.LVLBooK < 6)
        {
            _imagesBook.sprite = _imagesMenu[2];
            _imagesUp.sprite = _imagesMenu[3];
            _imagesDown.sprite = _imagesMenu[3];
            Text_book.text = "Адепт";
        }

        if (StatPers.LVLBooK >= 6)
        {
            _imagesBook.sprite = _imagesMenu[4];
            _imagesUp.sprite = _imagesMenu[5];
            _imagesDown.sprite = _imagesMenu[5];
            Text_book.text = "Маг";
        }
    }
    
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
        Buttoms[0].transform.DOScale(1.3f, 0.4f);
        Buttoms[1].transform.DOScale(1.0f, 0.4f);
        Buttoms[2].transform.DOScale(1.0f, 0.4f);
        Buttoms[3].transform.DOScale(1.0f, 0.4f);
    }
    public void BOOK()
    {
        Page1.SetActive(false);
        Page3.SetActive(false);
        Page2.SetActive(true);
        Page4.SetActive(false);
        Vizual();
        Buttoms[0].transform.DOScale(1.0f, 0.4f);
        Buttoms[1].transform.DOScale(1.3f, 0.4f);
        Buttoms[2].transform.DOScale(1.0f, 0.4f);
        Buttoms[3].transform.DOScale(1.0f, 0.4f);
        
    }
    public void EQUIP()
    {
        Page2.SetActive(false);
        Page1.SetActive(false);
        Page4.SetActive(false);
        Page3.SetActive(true);
        Vizual();
        Buttoms[0].transform.DOScale(1.0f, 0.4f);
        Buttoms[1].transform.DOScale(1.0f, 0.4f);
        Buttoms[2].transform.DOScale(1.3f, 0.4f);
        Buttoms[3].transform.DOScale(1.0f, 0.4f);
       

    }
    public void MainPage()
    {
        Page1.SetActive(true);
        Page2.SetActive(false);
        Page3.SetActive(false);
        Page4.SetActive(false);
        Vizual();
        Buttoms[0].transform.DOScale(1.3f, 0.4f);
        Buttoms[1].transform.DOScale(1.0f, 0.4f);
        Buttoms[2].transform.DOScale(1.0f, 0.4f);
        Buttoms[3].transform.DOScale(1.0f, 0.4f);
    }

    public void Shop()
    {
        Page1.SetActive(false);
        Page2.SetActive(false);
        Page3.SetActive(false);
        Page4.SetActive(true);
        Vizual();
        Buttoms[0].transform.DOScale(1.0f, 0.4f);
        Buttoms[1].transform.DOScale(1.0f, 0.4f);
        Buttoms[2].transform.DOScale(1.0f, 0.4f);
        Buttoms[3].transform.DOScale(1.3f, 0.4f);
    }
    
    private void FixedUpdate()
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
        for(int i = 0; i < StatPers.Ches.Length; i++)
        {
            if (StatPers.Ches[i]==true)
            {
                Chess.SetActive(true);
                break;
            }
            else
            {
                Chess.SetActive(false);
            }
        }
        

    }
    public void Enrgy_Plus()
    {
        StatPers.Now_Energy += 5;
    }
}
