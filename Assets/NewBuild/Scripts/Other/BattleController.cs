using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public GameConfig gameConfigPerson;
    public EnemyConfig enemyConfig;
    public CameraEffect cameraEffectController;
    
    
    
    public int hpPlayerInBattle;
    public int hpEnemyInBattle;
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
        UpdateTextField();
        if (gameConfigPerson.Skills[0])
        {
            damagePlayerInBattle +=(int)((damagePlayerInBattle/100.0f)*5.0f+5*gameConfigPerson.LVL_Skill[0]);
        }
    }

    private void Start()
    {
        var (player, enemy) = _gameСontainer.InitGameObjectToScene(gameConfigPerson, enemyConfig);
        
        _animationController = new AnimationController(player.GetComponent<Animator>(), enemy.GetComponent<Animator>(), _gameСontainer.counterAnimator);
        
        _skillController.Init(player.GetComponent<PlayerContainer>(), _animationController, _wordController, 
                    gameConfigPerson, this, _gameСontainer);
        
        _uiContainer.InitSkillsButton(_skillController,gameConfigPerson);
        
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
        if(hpPlayerInBattle <= 0)
        {
            StartCoroutine(DeathCharacter(CharacterEnum.Player));
        }
        if(hpEnemyInBattle <= 0)
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
        cameraEffectController.Final();
        yield return new WaitForSeconds(2.5f);
    }
    private IEnumerator SetDamage(CharacterEnum characterEnum)
    {
        _animationController.ExecuteAnimationSetDamage(characterEnum);
        yield return new WaitForSeconds(0.5f);
        _animationController.ExecuteAnimationGetDamage(characterEnum);
        switch (characterEnum)
        {
            case CharacterEnum.Player:
                hpEnemyInBattle -= damagePlayerInBattle;
                _gameСontainer.flyCounterEnemy.text = $"{damagePlayerInBattle}";
                _animationController.ExecuteCounterAnimation(characterEnum);
                break;
            case CharacterEnum.Enemy:
                var damage = damageEnemyInBattle - playerDefence;
                if (damage > 0)
                {
                    hpPlayerInBattle-=damage;
                    _gameСontainer.flyCounterPlayer.text = (damageEnemyInBattle - playerDefence).ToString();
                    _animationController.ExecuteCounterAnimation(characterEnum);
                }
                break;
            default: throw new ArgumentOutOfRangeException(nameof(characterEnum), characterEnum, null);
        }
       UpdateTextField();
       EventManager.cooldown?.Invoke();
       if(hpPlayerInBattle <= 0 || hpEnemyInBattle <= 0)
       {
           GameState = false;
           EndRound();
       }
    }
    private void UpdateTextField()
    {
        _uiContainer.sliderHpPlayer.maxValue = gameConfigPerson.hpPerson;
        _uiContainer.sliderHpPlayer.value = hpPlayerInBattle;
        _uiContainer.hpPlayerText.text = $"{hpPlayerInBattle}/{gameConfigPerson.hpPerson}";
        _uiContainer.hpSliderEnemy.maxValue = enemyConfig.hpEnemy;
        _uiContainer.hpSliderEnemy.value = hpEnemyInBattle;
        _uiContainer.hpTextEnemy.text = $"{hpEnemyInBattle}/{enemyConfig.hpEnemy}";
    }
    private void UpdateStatsHp()
    {
        hpPlayerInBattle = gameConfigPerson.hpPerson;
        hpEnemyInBattle = enemyConfig.hpEnemy;
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
