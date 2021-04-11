using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private HP HP =default;
    [SerializeField] private GameObject Window1 =default;
    [SerializeField] private GameObject Window2 = default;
    [SerializeField] private ChoiesLanguege ChoiesLanguege = default;
    [SerializeField] private MenuBut MenuBut = default;
    [SerializeField] private GameObject TutorialButtom = default;
    private void Start()
    {
        if (HP._Tutorial)
        {
            Tutorial();
            HP._Tutorial = false;
            HP.SaveData();
        }
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
        //StartCoroutine(StartGameCor(1));
    }
    public void StartGame()
    {
        if(ChoiesLanguege.Languge1 != ChoiesLanguege.Languge2 && HP.Now_Energy>=3)
        {
            HP.Now_Energy -= 3;
            HP.SaveData();
            //SceneManager.LoadScene(2);
            MenuBut.ActivPanel();
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

    public void Tutorial()
    {
        TutorialButtom.SetActive(true);
    }
}
