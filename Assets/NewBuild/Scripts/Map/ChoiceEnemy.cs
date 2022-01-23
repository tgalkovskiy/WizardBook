
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoiceEnemy : MonoBehaviour
{
    [SerializeField] private GameObject LoadGameObj = default;
    [SerializeField] private GameObject Discription = default;
    [SerializeField] private Text Text_Name = default;
    [SerializeField] private GameConfig gameConfig = default;
    [SerializeField] private EnemyConfig enemyConfig;

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