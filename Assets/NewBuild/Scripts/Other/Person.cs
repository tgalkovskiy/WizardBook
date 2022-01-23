using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Rendering.PostProcessing;

public class Person : MonoBehaviour
{
    [SerializeField] private CameraEffect CameraEffect;
    [SerializeField] private Reward reward;
    [SerializeField] private SkillManeger skillManeger;
    [SerializeField] private GameObject[] ActivElement = default;
    [SerializeField] private GameObject[] Weapon = default;
    [SerializeField] private GameObject[] EnemyGameObj = default;
    [SerializeField] private GameObject[] Hit;
    [SerializeField] private PostProcessVolume _process =default;
    private Vignette _vignette = default;
    
    [SerializeField] private GameConfig gameConfigPerson = default;
    [SerializeField] private EnemyConfig enemyConfig;
    public Animator playerAnimator;
    [SerializeField] private Slider sliderHPPlayer = default;
    [SerializeField] private Text hpPlayerText = default;
    [SerializeField] private Slider hpSliderEnemy = default;
    [SerializeField] private Text hpTextEnemy = default;
    [SerializeField] public int hpPlayerInBattle = 1;
    [HideInInspector]public int hpEnemyInBattle;
    [HideInInspector]public int damagePlayerInBattle;
    [HideInInspector]public int damageEnemyInBattle;
    [HideInInspector]static public bool GameState = true;
    [HideInInspector] public int playerDefence;
    [HideInInspector] public int Deffence_Standart_Lvl;
    [SerializeField] private TextMesh flyCounterPlayer;
    [SerializeField] private TextMesh flyCounterEnemy;
    [SerializeField] private Animator flyCounter;
    private GameObject Enemy;
    private Animator AnimatorEnemy;
    private void Awake()
    {
        gameConfigPerson.LoadData();
        GameState = true;
        UpdateStatsHp();
        UpdateStatsDamage();
        UpdateStatsArmor();
        UpdateTextField();
        Enemy=Instantiate(EnemyGameObj[enemyConfig.numberEnemy]);
        AnimatorEnemy = Enemy.GetComponent<Animator>();
        if (gameConfigPerson.Skills[0])
        {
            damagePlayerInBattle +=(int)((damagePlayerInBattle/100.0f)*5.0f+5*gameConfigPerson.LVL_Skill[0]);
        }
        Weapon[gameConfigPerson.NumberSworld].SetActive(true);
    }
    private void Start()
    {
        _process.profile.TryGetSettings(out _vignette);
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
        switch (characterEnum)
        {
            case CharacterEnum.Player:
                playerAnimator.SetTrigger("Die");
                reward.GetReward(false, enemyConfig, gameConfigPerson);
                break;
            case CharacterEnum.Enemy:
                AnimatorEnemy.SetTrigger("Die");
                reward.GetReward(true, enemyConfig, gameConfigPerson);
                break;
            default: throw new ArgumentOutOfRangeException(nameof(characterEnum), characterEnum, null);
        }
        CameraEffect.Final();
        yield return new WaitForSeconds(2.5f);
    }
    private IEnumerator SetDamage(CharacterEnum characterEnum)
    {
        switch (characterEnum)
        {
            case CharacterEnum.Player: playerAnimator.SetTrigger("Attack"); break;
            case CharacterEnum.Enemy: AnimatorEnemy.SetTrigger("Attack"); break;
            default: throw new ArgumentOutOfRangeException(nameof(characterEnum), characterEnum, null);
        }
        yield return new WaitForSeconds(0.5f);
        switch (characterEnum)
        {
            case CharacterEnum.Player: AnimatorEnemy.SetTrigger("Damage");
                hpEnemyInBattle -= damagePlayerInBattle;
                flyCounterEnemy.text = $"{damagePlayerInBattle}";
                flyCounter.SetTrigger("Eny");
                break;
            case CharacterEnum.Enemy: playerAnimator.SetTrigger("Damage");
                var damage = damageEnemyInBattle - playerDefence;
                if (damage > 0)
                {
                    hpPlayerInBattle-=damage;
                    flyCounterPlayer.text = (damageEnemyInBattle - playerDefence).ToString();
                    flyCounter.SetTrigger("Pers");
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
        sliderHPPlayer.maxValue = gameConfigPerson.hpPerson;
        sliderHPPlayer.value = hpPlayerInBattle;
        hpPlayerText.text = $"{hpPlayerInBattle}/{gameConfigPerson.hpPerson}";
        hpSliderEnemy.maxValue = enemyConfig.hpEnemy;
        hpSliderEnemy.value = hpEnemyInBattle;
        hpTextEnemy.text = $"{hpEnemyInBattle}/{enemyConfig.hpEnemy}";
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
