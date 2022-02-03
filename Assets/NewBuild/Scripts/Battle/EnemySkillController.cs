
using System.Threading.Tasks;
using UnityEngine;

public class EnemySkillController
{
    private BattleController _battleController;
    private GameConfig _playerConfig;
    private EnemyConfig _enemyConfig;
    private GameСontainer _сontainer;
    private WordController _wordController;
    private UiContainer _uiContainer;

    public EnemySkillController(BattleController battleController, WordController wordController, UiContainer uiContainer, 
        GameConfig gameConfig, EnemyConfig enemyConfig, GameСontainer gameСontainer)
    {
        _battleController = battleController;
        _playerConfig = gameConfig;
        _enemyConfig = enemyConfig;
        _сontainer = gameСontainer;
        _wordController = wordController;
        _uiContainer = uiContainer;
        switch(_enemyConfig.enemyAbilityEnum)
        {
            case EnemyAbilityEnum.Poisoning: _сontainer.potionPartical.SetActive(true); break;
            case EnemyAbilityEnum.Weakness: _сontainer.weaknessFogPartical.SetActive(true);
                _battleController.damagePlayerInBattle /= 2; break;
            case EnemyAbilityEnum.FastDamage: _сontainer.fastDamagePartical.SetActive(true);
                _battleController.damageEnemyInBattle *= 2; break;
            case EnemyAbilityEnum.Entanglement:
                _wordController.changeWord = true; break;
            case EnemyAbilityEnum.AntiMagic:
                _uiContainer.buttonArson.interactable = false;
                _uiContainer.buttonShield.interactable = false;
                _uiContainer.buttonTimeStop.interactable = false;
                _uiContainer.buttonDeleteWrongWord.interactable = false;
                _сontainer.antiMagicFog.SetActive(true);
                break;
        }
    }
    
    public async void ExecuteEnemyAbility()
    {
        switch(_enemyConfig.enemyAbilityEnum)
        {
            case EnemyAbilityEnum.Poisoning:
                float damagePotion = ((_playerConfig.hpPerson / 100) * 5);
                damagePotion -= (damagePotion / 100) * _playerConfig.resitPotion;
                _battleController.HpPlayerInBattle =(int)damagePotion;
                await Task.Delay(500);
                CounterDamage.TextRises(CharacterEnum.Enemy, _сontainer.canvas, _сontainer.textPrefab, $"-{(int)damagePotion}", Color.green);
                break;
            case EnemyAbilityEnum.Arson:
                float damageArson = ((_playerConfig.hpPerson / 100) * 12);
                damageArson -= (damageArson / 100) * _playerConfig.resitFire;
                _battleController.HpPlayerInBattle =(int)damageArson;
                _сontainer.arsonDamage.gameObject.SetActive(true);
                _сontainer.arsonDamage.Play();
                await Task.Delay(500);
                CounterDamage.TextRises(CharacterEnum.Enemy, _сontainer.canvas, _сontainer.textPrefab, $"-{(int)damageArson}", new Color(0.9f, 0.5f, 0.3f,1));
                break;
            case EnemyAbilityEnum.Freezing: 
                float damageFreezing = ((_playerConfig.hpPerson / 100) * 10);
                damageFreezing -= (damageFreezing / 100) * _playerConfig.resitFire;
                _battleController.HpPlayerInBattle =(int)damageFreezing;
                _сontainer.freezingDamage.gameObject.SetActive(true);
                _сontainer.freezingDamage.Play();
                await Task.Delay(500);
                CounterDamage.TextRises(CharacterEnum.Enemy, _сontainer.canvas, _сontainer.textPrefab, $"-{(int)damageFreezing}", Color.cyan);
                break;
            case EnemyAbilityEnum.Entanglement:
                _сontainer.entanglementPartical.gameObject.SetActive(true);
                _сontainer.entanglementPartical.Play();
                break;
            
        }
    }
}
