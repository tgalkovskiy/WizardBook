using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Reward : MonoBehaviour
{
    public GameObject finalPanel;
    public Transform positionFinalPanel;
    public Text rewardGoldText;
    public Text rewardRubinText;
    public Text rewardBattleExpText;
    public Text rewardBookExpText;
    public Text endGameText;
    public GameObject nextLvlPanel;
    public GameObject getChesPanel;
    public Map map;

    public void GetReward(bool isWin, EnemyConfig config, GameConfig gameConfig)
    {
        if(!isWin)
        {
            endGameText.text = $"В ЭТОТ РАЗ ТЫ ПРОИГРАЛ...\nУЛУЧШАЙ СНАРЯЖЕНИЕ И ПРОКАЧИВАЙ НАВЫКИ";
            rewardGoldText.text = $"{config.rewardGoldEnemy} МОНЕТ";
            rewardRubinText.text = $"{config.rewardRubin} КРИСТАЛЛОВ";
            rewardBattleExpText.text = $"{config.rewardBattleExpEnemy}";
            //rewardBookExpText.text = $"{config.rewardExpBookEnemy}";
            getChesPanel.SetActive(config.rewardChes);
            gameConfig.Gold += config.rewardGoldEnemy;
            gameConfig.Rubin += config.rewardRubin;
            gameConfig.NowXP += config.rewardBattleExpEnemy;
            gameConfig.Now_BOOK_XP += config.rewardExpBookEnemy;
            if(config.rewardChes) gameConfig.ches += 1;
        }
        else
        {
            endGameText.text = $"ПОБЕДА! ТАК ДЕРЖАТЬ!";
            rewardGoldText.text = $"{config.rewardGoldEnemy/5} МОНЕТ";
            rewardRubinText.text = $"{0} КРИСТАЛЛОВ";
            rewardBattleExpText.text = $"{config.rewardBattleExpEnemy/10}";
            //rewardBookExpText.text = $"{config.rewardExpBookEnemy/10}";
            gameConfig.Gold += config.rewardGoldEnemy;
            gameConfig.Rubin += config.rewardRubin;
            gameConfig.NowXP += config.rewardBattleExpEnemy;
            gameConfig.Now_BOOK_XP += config.rewardExpBookEnemy;
            map.enemyNumber[config.numberEnemy+1] = true;
            map.SaveData();
        }
        if(gameConfig.NowXP>=gameConfig.NextLVLXP) gameConfig.NextLVL();
        gameConfig.SaveData();
        finalPanel.transform.DOMove(positionFinalPanel.position, 1f);
    }
}
