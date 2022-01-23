using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    public int lvlBookEnemy;
    public int numberEnemy = 0;
    public int hpEnemy;
    public int damageEnemy;
    public int rewardGoldEnemy;
    public int rewardBattleExpEnemy;
    public int rewardExpBookEnemy;
    public int rewardRubin;
    public bool rewardChes;

    public void SelectEnemy(StatsEnemy statsEnemy)
    {
        lvlBookEnemy = statsEnemy.lvlBook;
        numberEnemy = statsEnemy.numberEnemy;
        hpEnemy = statsEnemy.hP;
        damageEnemy = statsEnemy.damage;
        rewardGoldEnemy = statsEnemy.rewardGold;
        rewardBattleExpEnemy = statsEnemy.rewardBattleExp;
        rewardExpBookEnemy = statsEnemy.rewardBookExp;
        rewardRubin = statsEnemy.rewardRubin;
        rewardChes = statsEnemy.rewardChes;
    }
}
