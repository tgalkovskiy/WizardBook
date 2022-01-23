using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action playerAction;
    public static Action enemyAction;
    public static Action cooldown;
    public Person person;
    public WordButtom wordButtom;
    public SkillManeger skillManeger;
    public WordLoad wordLoad;

    private void OnEnable()
    {
        playerAction += person.AttackPlayer;
        enemyAction += person.AttackEnemy;
        playerAction += wordLoad.LoadText;
        enemyAction += wordLoad.LoadText;
        playerAction += wordButtom.Word;
        enemyAction += wordButtom.Word;
        playerAction += wordButtom.BattleTimer;
        enemyAction += wordButtom.BattleTimer;
        playerAction += wordButtom.MovesCount;
        enemyAction += wordButtom.MovesCount;
        cooldown += skillManeger.UpdateCooldown;
    }

    private void OnDisable()
    {
        playerAction -= person.AttackPlayer;
        enemyAction -= person.AttackEnemy;
        playerAction -= wordLoad.LoadText;
        enemyAction -= wordLoad.LoadText;
        playerAction -= wordButtom.Word;
        enemyAction -= wordButtom.Word;
        playerAction -= wordButtom.BattleTimer;
        enemyAction -= wordButtom.BattleTimer;
        playerAction -= wordButtom.MovesCount;
        enemyAction -= wordButtom.MovesCount;
        cooldown -= skillManeger.UpdateCooldown;
    }
}
