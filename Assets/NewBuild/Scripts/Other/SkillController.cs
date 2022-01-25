using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    private AnimationController _animationController;
    private GameConfig _gameConfigSKills;
    private BattleController _battleController;
    private WordController _wordController;
    private PlayerContainer _playerContainer;
    private GameСontainer _gameСontainer;

    private int EndArson =0;
    private int CooldownArson = 0;
    private int ArsonDamege;
    //защита скил
    
    private int End_Deff = 0;
    public static int Cooldown_Deff = 0;
    //замедление скилл
   
    private int EndTime =0;
    public static int CoolDown_Time = 0;
    
    private int End_Watter =0;
    public static int Cooldown_Watter = 0;
    public void Init(PlayerContainer playerContainer, AnimationController animationController, WordController wordController,
        GameConfig config, BattleController battleController, GameСontainer gameСontainer)
    {
        _animationController = animationController;
        _playerContainer = playerContainer;
        _gameСontainer = gameСontainer;
        _wordController = wordController;
        _gameConfigSKills = config;
        _battleController = battleController;
        Cooldown_Deff = 0;
        CoolDown_Time = 0;
        Cooldown_Watter = 0;
        
        if(_gameConfigSKills.Skills[0])
        {
            _playerContainer.fireAuraPartical.SetActive(true);
        }
        if(_gameConfigSKills.Skills[1])
        {
            ArsonDamege = (_battleController.hpEnemyInBattle / 100) * (2+1*_gameConfigSKills.LVL_Skill[1]);
        }
        if(_gameConfigSKills.Skills[2])
        {
            _battleController.damagePlayerInBattle += (_battleController.damagePlayerInBattle / 100) * (25+ _gameConfigSKills.LVL_Skill[2]);
            ArsonDamege += (ArsonDamege / 100) * (25+10*_gameConfigSKills.LVL_Skill[2]);
        }
        if(_gameConfigSKills.Skills[6])
        {
            _battleController.playerDefence += (_battleController.playerDefence / 100) * (5+ _gameConfigSKills.LVL_Skill[6]);
        }
        if(_gameConfigSKills.Skills[10])
        {
            _wordController.timerInRaund += 2+_gameConfigSKills.LVL_Skill[9];
        }
        UpdateCooldown();
    }
    public void UpdateCooldown()
    {
        if (_gameConfigSKills.Skills[1])
        {
            if(_wordController.Moves >= EndArson)
            {
                _gameСontainer.fireEnemy.SetActive(false);
                EventManager.playerAction -= Arson;
                EventManager.enemyAction -= Arson;
            }
            if(_wordController.Moves >= CooldownArson)
            {
                CooldownArson = 0;
            }
        }
        if (_gameConfigSKills.Skills[7])
        {
            if(_wordController.Moves >= End_Deff)
            {
                _playerContainer.shildPartical.SetActive(false);
                _battleController.playerDefence = _battleController.standardDefencePlayer;
            }
            if(_wordController.Moves >= Cooldown_Deff)
            {
                Cooldown_Deff = 0;
            }
        }
        if (_gameConfigSKills.Skills[9])
        {
            if (_wordController.Moves >= EndTime)
            {
                Time.timeScale = 1;
                _playerContainer.timeStopPartical.SetActive(false);
            }
            if(_wordController.Moves >= CoolDown_Time)
            {
                CoolDown_Time = 0;
            }
        }
        if (_gameConfigSKills.Skills[3])
        {
            if(_wordController.Moves >= End_Watter)
            {
                Cooldown_Watter = 0;
                _playerContainer.deleteWrongWordPartical.SetActive(false);
            }
            if(_wordController.Moves >= Cooldown_Watter)
            {
                Cooldown_Watter = 0;
            }
        }
    }
    public void ActiveArson()
    {
        if(CooldownArson == 0)
        {
            StartCoroutine(ExecuteArson());
        }
       
    }
    public void ActiveShield()
    {
        if(Cooldown_Deff == 0)
        {
            StartCoroutine(ExecuteShield());
        }
    }
    public void ActiveTimeStop()
    {
        if (CoolDown_Time != 0) return;
        _animationController.ExecuteAnimationSkillPlayer(EnumAbilityPlayer.TimeStop);
        Time.timeScale = 0.5f;
        CoolDown_Time = _wordController.Moves + 6 - _gameConfigSKills.LVL_Skill[10];
        EndTime = _wordController.Moves + 1;
    }
    public void ActiveDeleteWrongWord()
    {
        if (Cooldown_Watter != 0) return;
        _animationController.ExecuteAnimationSkillPlayer(EnumAbilityPlayer.DeleteWrongWord);
        _playerContainer.deleteWrongWordPartical.SetActive(true);
        _wordController.Delete_Word();
        Cooldown_Watter = _wordController.Moves + 6 - _gameConfigSKills.LVL_Skill[3];
        End_Watter = _wordController.Moves + 1;
    }
    public void Arson()
    {
        _battleController.hpEnemyInBattle -= ArsonDamege;
    }
    private IEnumerator ExecuteShield()
    {
        _animationController.ExecuteAnimationSkillPlayer(EnumAbilityPlayer.Shield);
        _battleController.playerDefence = 10000000;
        Cooldown_Deff = _wordController.Moves + 6-_gameConfigSKills.LVL_Skill[7];
        End_Deff = _wordController.Moves + 1;
        yield return new WaitForSeconds(1);
        _playerContainer.shildPartical.SetActive(true);
    }
    private IEnumerator ExecuteArson()
    {
        _animationController.ExecuteAnimationSkillPlayer(EnumAbilityPlayer.Arson);
        EndArson = _wordController.Moves + 3;
        CooldownArson = _wordController.Moves + 6;
        yield return new WaitForSeconds(2);
        _gameСontainer.fireEnemy.SetActive(true);
        EventManager.playerAction += Arson;
        EventManager.enemyAction += Arson;
    } 
}
