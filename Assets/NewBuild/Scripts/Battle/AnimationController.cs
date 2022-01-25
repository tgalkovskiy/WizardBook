
using UnityEngine;
public class AnimationController
{
    private Animator _player;
    private Animator _enemy;
    private Animator _wordCounter;

    public AnimationController(Animator playerAnimator, Animator enemyAnimator, Animator wordCounter)
    {
        _player = playerAnimator;
        _enemy = enemyAnimator;
        _wordCounter = wordCounter;
    }

    public void ExecuteCounterAnimation(CharacterEnum characterEnum)
    {
        switch(characterEnum)
        {
            case CharacterEnum.Player:
                _wordCounter.SetTrigger("Eny");
                break;
            case CharacterEnum.Enemy:
                _wordCounter.SetTrigger("Pers");
                break;
        }
    }
    public void ExecuteAnimationSetDamage(CharacterEnum characterEnum)
    {
        switch(characterEnum)
        {
            case CharacterEnum.Player:
                _player.SetTrigger("Attack");
                break;
            case CharacterEnum.Enemy:
                _enemy.SetTrigger("Attack");
                break;
        }
    }

    public void ExecuteAnimationGetDamage(CharacterEnum characterEnum)
    {
        switch(characterEnum)
        {
            case CharacterEnum.Player:
                _enemy.SetTrigger("Damage");
                break;
            case CharacterEnum.Enemy:
                _player.SetTrigger("Damage");
                break;
        }
    }

    public void ExecuteAnimationDeathCharacter(CharacterEnum characterEnum)
    {
        switch(characterEnum)
        {
            case CharacterEnum.Player:
                _player.SetTrigger("Die");
                break;
            case CharacterEnum.Enemy:
                _enemy.SetTrigger("Die");
                break;
        }
    }
    public void ExecuteAnimationSkillPlayer(EnumAbilityPlayer abilityPlayer)
    {
        switch (abilityPlayer)
        {
            case EnumAbilityPlayer.Arson: _player.SetTrigger("Arson"); break;
            case EnumAbilityPlayer.Shield: _player.SetTrigger("Shild"); break;
            case EnumAbilityPlayer.DeleteWrongWord: _player.SetTrigger("DeleteWord"); break;
            case EnumAbilityPlayer.TimeStop: _player.SetTrigger("StopTime"); break;
        }
    }
}
