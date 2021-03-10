﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private HP HP;
    [SerializeField] private GameObject Window1;
    [SerializeField] private GameObject Window2;
    [SerializeField] private ChoiesLanguege ChoiesLanguege;
    [SerializeField] private MenuBut MenuBut;
    private void Start()
    {
        
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
        //StartCoroutine(StartGameCor(1));
    }
    public void Fortuna()
    {
        SceneManager.LoadScene(2);
    }
    public void StartGame()
    {
        if(ChoiesLanguege.Languge1 != ChoiesLanguege.Languge2 && HP.Now_Energy>=5)
        {
            HP.Now_Energy -= 3;
            HP.SaveData();
            SceneManager.LoadScene(2);
            //MenuBut.ActivPanel();
            //StartCoroutine(StartGameCor(2));
        }
        if(HP.Now_Energy < 3)
        {
            Window2.SetActive(true);
        }
        if(ChoiesLanguege.Languge1 == ChoiesLanguege.Languge2)
        {
            Window1.SetActive(true);
        }
        
    }
    public void FirstScene()
    {
        //StartCoroutine(StartGameCor(1));
        SceneManager.LoadScene(1);
    }
    IEnumerator StartGameCor(int ID)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(ID);
        if (!async.isDone)
        {
            yield return null;
        }
        
    }
    public void Exit()
    {
        HP.SaveData();
        Application.Quit();
    }

    public void Close_Window(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
