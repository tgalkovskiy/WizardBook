
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoisEnemy : MonoBehaviour
{
    [SerializeField] private GameObject LoadGameObj = default;
    [SerializeField] private GameObject Discription = default;
    [SerializeField] private Text Text_Name = default;
    [SerializeField] private GameConfig gameConfig = default;

    public void OnclicEnemy(StatEnemy statEnemy)
    {
        gameConfig.NumberEnemy = statEnemy.NumberEnemy;
        gameConfig.lvlEnemy = statEnemy.lvlBook;
        gameConfig.HP_Enemy = statEnemy.HP;
        gameConfig.Damage = statEnemy.Damage;
        gameConfig.Gold_enemy = statEnemy.Gold;
        gameConfig.Exp_enmy_book = statEnemy.ExpBook;
        gameConfig.Exp_enemy = statEnemy.Exp;
        gameConfig.Rubin_Enemy = statEnemy.Rubin;
        gameConfig.Chess_Drop = statEnemy.Chess;
        Text_Name.text = statEnemy.Name;
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