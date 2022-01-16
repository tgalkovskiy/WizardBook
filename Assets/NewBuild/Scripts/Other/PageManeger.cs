using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class PageManeger : MonoBehaviour
{
    public GameConfig stat;

    [SerializeField] private SaveTutorial _tutorial = default;
    [SerializeField] private GameObject First_tutorial = default;
    
    [SerializeField] private GameObject[] page =default;
    [SerializeField] private GameObject[] buttoms = default;
    [SerializeField] private Image bgImage = default; 
    [SerializeField] private Sprite[] bgSprite = default;
    
    [SerializeField] private GameObject NextLVLMainPage = default;
    [SerializeField] private GameObject NextLVlBG = default;
    [SerializeField] private GameObject Chess = default;

    [SerializeField] private Text Text_book = default;
    
    /*[SerializeField] private Sprite[] _imagesMenu = default;
    [SerializeField] private Image _imagesBook = default;
    [SerializeField] private Image _imagesUp = default;
    [SerializeField] private Image _imagesDown = default;*/

    
    public void Vizual()
    {
        if (stat.LVLBooK < 3)
        {
            /*_imagesBook.sprite = _imagesMenu[0];
            _imagesUp.sprite = _imagesMenu[1];
            _imagesDown.sprite = _imagesMenu[1];*/
            Text_book.text = "Ученик";
        }

        if (stat.LVLBooK >= 3 && stat.LVLBooK < 6)
        {
            /*_imagesBook.sprite = _imagesMenu[2];
            _imagesUp.sprite = _imagesMenu[3];
            _imagesDown.sprite = _imagesMenu[3];*/
            Text_book.text = "Адепт";
        }

        if (stat.LVLBooK >= 6)
        {
            /*_imagesBook.sprite = _imagesMenu[4];
            _imagesUp.sprite = _imagesMenu[5];
            _imagesDown.sprite = _imagesMenu[5];*/
            Text_book.text = "Маг";
        }
    }

    private void Start()
    {
        stat.LoadData();
        _tutorial.LoadData();
        Uimanager.ChangeMainResurses(stat, MainResurses.Instance.gold, MainResurses.Instance.energy, MainResurses.Instance.rubin);
        if (!_tutorial.first_tutorial)
        {
            First_tutorial.SetActive(true);
            _tutorial.first_tutorial = true;
            _tutorial.SaveData();
        }
        //MainPage(0);
        if (stat.Now_BOOK_XP >= stat.NextLVL_BOOK_XP)
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
    
    private void FixedUpdate()
    {
        for(int i = 0; i < stat.Ches.Length; i++)
        {
            if (stat.Ches[i]==true)
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
        stat.Now_Energy += 5;
    }

    private void ShowReclama()
    {
        int varity = Random.Range(0, 9);
        if (varity == 7)
        {
            Energy.Instanse.addRevard();
        }
        else if(varity == 8)
        {
            Energy.Instanse.AddАVideo();
        }
        else if (varity == 9)
        {
           Energy.Instanse.Baner(); 
        }
    }

    /*public void MainPage(int indexpage)
    {
        Uimanager.SwitchPage(indexpage, page, buttoms);
        bgImage.sprite = bgSprite[indexpage];
    }*/

    public void BookPage(int indexpage)
    {
        Uimanager.SwitchPage(indexpage, page, buttoms);
        bgImage.sprite = bgSprite[indexpage];
    }

    public void ShopPage(int indexpage)
    {
        Uimanager.SwitchPage(indexpage, page, buttoms);
        bgImage.sprite = bgSprite[indexpage];
    }

    public void Equipment(int indexpage)
    {
        Uimanager.SwitchPage(indexpage, page, buttoms);
        bgImage.sprite = bgSprite[indexpage];
    }
}
