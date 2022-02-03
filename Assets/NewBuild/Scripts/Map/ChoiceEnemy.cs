
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoiceEnemy : MonoBehaviour
{
    [SerializeField] private GameObject LoadGameObj = default;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject Discription = default;
    [SerializeField] private Text Text_Name = default;
    [SerializeField] private EnemyConfig enemyConfig;

    private void Awake()
    {
        exitButton.onClick.AddListener((() => SceneController.LoadScene(1)));
    }

    public void SelectEnemy(StatsEnemy statsEnemy)
    {
        if(!statsEnemy.isOpen) return; 
        enemyConfig.SelectEnemy(statsEnemy);
        Text_Name.text = statsEnemy.Name;
        Discription.SetActive(true);
    }

    public void PlayGame()
    {
        LoadGameObj.SetActive(true);
    }

    public void Back()
    {
        Discription.SetActive(false);
    }
    public void Menu()
    {
        SceneManager.LoadScene(1);
    }
}