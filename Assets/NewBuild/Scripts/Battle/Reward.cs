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
    public Text endGameText;
    public GameObject nextLvlPanel;
    public GameObject getChesPanel;
    public Map map;

    public void GetReward(bool isWin, EnemyConfig config, GameConfig gameConfig)
    {
        if(isWin)
        {
            endGameText.text = $"ПОБЕДА! ТАК ДЕРЖАТЬ!";
            rewardGoldText.text = $"{config.rewardGoldEnemy} МОНЕТ";
            rewardRubinText.text = $"{config.rewardRubin} КРИСТАЛЛОВ";
            getChesPanel.SetActive(config.rewardChes);
            rewardBattleExpText.text = $"{config.rewardBattleExpEnemy}";
            gameConfig.Gold += config.rewardGoldEnemy;
            gameConfig.Rubin += config.rewardRubin;
            gameConfig.NowXP += config.rewardBattleExpEnemy;
            gameConfig.Now_BOOK_XP += config.rewardExpBookEnemy;
            map.enemyNumber[config.numberEnemy+1] = true;
            if(config.rewardChes) gameConfig.ches += 1;
            map.SaveData();
            
        }
        else
        {
            endGameText.text = $"В ЭТОТ РАЗ ТЫ ПРОИГРАЛ...\nУЛУЧШАЙ СНАРЯЖЕНИЕ И ПРОКАЧИВАЙ НАВЫКИ";
            rewardGoldText.text = $"{config.rewardGoldEnemy/5} МОНЕТ";
            rewardRubinText.text = $"{0} КРИСТАЛЛОВ";
            rewardBattleExpText.text = $"{config.rewardBattleExpEnemy}";
            gameConfig.Gold += config.rewardGoldEnemy/5;
            gameConfig.NowXP += config.rewardBattleExpEnemy/5;
            gameConfig.Now_BOOK_XP += config.rewardExpBookEnemy/5;
        }
        if(gameConfig.NowXP>=gameConfig.NextLVLXP) gameConfig.NextLVL();
        gameConfig.SaveData();
        finalPanel.transform.DOMove(positionFinalPanel.position, 1f);
    }
}
