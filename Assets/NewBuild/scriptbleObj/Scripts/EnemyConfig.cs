using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    public int lvlBookEnemy;
    public EnemyEnum enemyEnum;
    public int numberEnemy = 0;
    public int hpEnemy;
    public int damageEnemy;
    public int rewardGoldEnemy;
    public int rewardBattleExpEnemy;
    public int rewardExpBookEnemy;
    public int rewardRubin;
    public bool rewardChes;
    public EnemyAbilityEnum enemyAbilityEnum;

    public GameObject frogman;
    public GameObject ogrBase;
    public GameObject ogrWarrior;
    public GameObject ogrShaman;
    public GameObject ent;
    public GameObject iceGolem;
    public GameObject stoneGolem;
    public GameObject fireGolem;
    public void SelectEnemy(StatsEnemy statsEnemy)
    {
        lvlBookEnemy = statsEnemy.lvlBook;
        numberEnemy = statsEnemy.numberEnemy;
        hpEnemy = statsEnemy.hP;
        enemyEnum = statsEnemy.enemyEnum;
        damageEnemy = statsEnemy.damage;
        rewardGoldEnemy = statsEnemy.rewardGold;
        rewardBattleExpEnemy = statsEnemy.rewardBattleExp;
        rewardExpBookEnemy = statsEnemy.rewardBookExp;
        rewardRubin = statsEnemy.rewardRubin;
        rewardChes = statsEnemy.rewardChes;
        enemyAbilityEnum = statsEnemy.enemyAbilityEnum;
    }

    public GameObject SelectEnemyPrefab()
    {
        return enemyEnum switch
        {
            EnemyEnum.Frogman => frogman,
            EnemyEnum.OgrBase => ogrBase,
            EnemyEnum.OgrWarrior => ogrWarrior,
            EnemyEnum.OgrShaman => ogrShaman,
            EnemyEnum.GolemIce => iceGolem,
            EnemyEnum.GolemStone => stoneGolem,
            EnemyEnum.GolemFire => fireGolem,
            EnemyEnum.Ent => ent,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
