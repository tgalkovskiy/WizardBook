using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action playerAction;
    public static Action enemyAction;
    public static Action cooldown;
    public BattleController battleController;
    public WordController wordController;
    public SkillController skillController;

    private void OnEnable()
    {
        playerAction += battleController.AttackPlayer;
        enemyAction += battleController.AttackEnemy;
        playerAction += wordController.Word;
        enemyAction += wordController.Word;
        playerAction += wordController.BattleTimer;
        enemyAction += wordController.BattleTimer;
        playerAction += wordController.MovesCount;
        enemyAction += wordController.MovesCount;
        cooldown += skillController.UpdateCooldown;
    }

    private void OnDisable()
    {
        playerAction -= battleController.AttackPlayer;
        enemyAction -= battleController.AttackEnemy;
        playerAction -= wordController.Word;
        enemyAction -= wordController.Word;
        playerAction -= wordController.BattleTimer;
        enemyAction -= wordController.BattleTimer;
        playerAction -= wordController.MovesCount;
        enemyAction -= wordController.MovesCount;
        cooldown -= skillController.UpdateCooldown;
    }
}
