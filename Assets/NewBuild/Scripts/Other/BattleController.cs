using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public GameConfig gameConfigPerson;
    public EnemyConfig enemyConfig;
    public CameraEffect cameraEffectController;
    public int _hpPlayerInBattle;
    public int _hpEnemyInBattle;
    public int HpPlayerInBattle
    {
        set
        {
            _hpPlayerInBattle -=value;
            _uiContainer.UpdateHpPlayer(_hpPlayerInBattle, gameConfigPerson.hpPerson);
        }
    }
    public int HpEnemyInBattle
    {
        set
        {
            _hpEnemyInBattle -=value;
            _uiContainer.UpdateHpEnemy(_hpEnemyInBattle, enemyConfig.hpEnemy);
        }
    }
    
    public int damagePlayerInBattle;
    public int damageEnemyInBattle;
    public static bool GameState = true;
    public int playerDefence;
    public int standardDefencePlayer;
    
    private Reward _reward;
    private UiContainer _uiContainer;
    private AnimationController _animationController;
    private SkillController _skillController;
    private GameСontainer _gameСontainer;
    private WordController _wordController;
    private EnemySkillController _enemySkillController;
    private void Awake()
    {
        _reward = GetComponent<Reward>();
        _uiContainer = GetComponent<UiContainer>();
        _skillController = GetComponent<SkillController>();
        _gameСontainer = GetComponent<GameСontainer>();
        _wordController = GetComponent<WordController>();
        gameConfigPerson.LoadData();
        GameState = true;
        UpdateStatsHp();
        UpdateStatsDamage();
        UpdateStatsArmor();
        if (gameConfigPerson.Skills[0])
        {
            damagePlayerInBattle +=(int)((damagePlayerInBattle/100.0f)*5.0f+5*gameConfigPerson.LVL_Skill[0]);
        }
    }

    private void Start()
    {
        var (player, enemy) = _gameСontainer.InitGameObjectToScene(gameConfigPerson, enemyConfig);
        
        _animationController = new AnimationController(player.GetComponent<Animator>(), enemy.GetComponent<Animator>());
        
        _skillController.Init(player.GetComponent<PlayerContainer>(), _animationController, _wordController, 
                    gameConfigPerson, this, _gameСontainer);
        
        _uiContainer.InitSkillsButton(_skillController,gameConfigPerson);

        _enemySkillController = new EnemySkillController(this, _wordController, _uiContainer, gameConfigPerson, enemyConfig, _gameСontainer);
    }

    public void AttackPlayer()
    {
        StartCoroutine(SetDamage(CharacterEnum.Player));
    }
    public void AttackEnemy()
    {
        StartCoroutine(SetDamage(CharacterEnum.Enemy));
    }
    private void EndRound()
    {
        if(_hpPlayerInBattle <= 0)
        {
            StartCoroutine(DeathCharacter(CharacterEnum.Player));
        }
        if(_hpEnemyInBattle <= 0)
        {
            StartCoroutine(DeathCharacter(CharacterEnum.Enemy));
        }
    }
    private IEnumerator DeathCharacter(CharacterEnum characterEnum)
    {
        _animationController.ExecuteAnimationDeathCharacter(characterEnum);
        switch(characterEnum)
        {
            case CharacterEnum.Player: _reward.GetReward(false, enemyConfig, gameConfigPerson); break;
            case CharacterEnum.Enemy: _reward.GetReward(true, enemyConfig, gameConfigPerson); break;
            default: throw new ArgumentOutOfRangeException(nameof(characterEnum), characterEnum, null);
        }
        yield return new WaitForSeconds(2.5f);
    }
    private IEnumerator SetDamage(CharacterEnum characterEnum)
    {
        _animationController.ExecuteAnimationSetDamage(characterEnum);
        yield return new WaitForSeconds(1f);
        _animationController.ExecuteAnimationGetDamage(characterEnum);
        switch (characterEnum)
        {
            case CharacterEnum.Player:
                HpEnemyInBattle =damagePlayerInBattle;
                CounterDamage.TextRises(CharacterEnum.Player, _gameСontainer.canvas, _gameСontainer.textPrefab, (-damagePlayerInBattle).ToString(), Color.red);
                break;
            case CharacterEnum.Enemy:
                HpPlayerInBattle = damageEnemyInBattle;
                CounterDamage.TextRises(CharacterEnum.Enemy, _gameСontainer.canvas,_gameСontainer.textPrefab, (-damageEnemyInBattle).ToString(), Color.red);
                break;
            default: throw new ArgumentOutOfRangeException(nameof(characterEnum), characterEnum, null);
        }
        _enemySkillController.ExecuteEnemyAbility();
        EventManager.cooldown?.Invoke();
       if(_hpPlayerInBattle <= 0 || _hpEnemyInBattle <= 0)
       {
           GameState = false;
           EndRound();
       }
    }
    private void UpdateStatsHp()
    {
        _hpPlayerInBattle = gameConfigPerson.hpPerson;
        _hpEnemyInBattle = enemyConfig.hpEnemy;
        _uiContainer.UpdateHpPlayer(_hpPlayerInBattle, gameConfigPerson.hpPerson);
        _uiContainer.UpdateHpEnemy(_hpEnemyInBattle, enemyConfig.hpEnemy);
    }
    private void UpdateStatsDamage()
    {
        damagePlayerInBattle = gameConfigPerson.damagePerson;
        damageEnemyInBattle = enemyConfig.damageEnemy;
    }
    private void UpdateStatsArmor()
    {
        playerDefence = gameConfigPerson.defencePerson;
    }

}
