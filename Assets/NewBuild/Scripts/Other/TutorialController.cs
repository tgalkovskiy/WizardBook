
using System;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public TutorialEnum tutorialEnum;
    [SerializeField]private SaveTutorial _tutorial;
    [SerializeField]private Text _tutorialTextView;
    [SerializeField] private Button nextMessageTutorial;
    private int indexMessage = 0; 
    private void Start()
    {
        _tutorial.LoadData();
        nextMessageTutorial.onClick.AddListener(UpdateTextTutorial);
        InitTutorial(tutorialEnum);
    }
    public void InitTutorial(TutorialEnum tutorialEnum)
    {
        switch (tutorialEnum)
        {
            case TutorialEnum.FirsHomePageLaunch: 
                if(_tutorial.firstLaunchHome) return;
                else
                {
                    _tutorialTextView.text = _tutorial.homeText[0];
                    _tutorial.firstLaunchHome = true;
                }
                break;
            case TutorialEnum.FirsMapPageLaunch:
                if(_tutorial.firstLaunchMap) return;
                else
                {
                    _tutorialTextView.text = _tutorial.mapText[0];
                    _tutorial.firstLaunchMap = true;
                }
                break;
            case TutorialEnum.FirsBattlePageLaunch:
                if(_tutorial.firstLaunchBattle) return;
                else
                {
                    _tutorialTextView.text = _tutorial.battleText[0];
                    _tutorial.firstLaunchBattle = true;
                }
                break;
            case TutorialEnum.FirsWinBattlePageLaunch:
                if(_tutorial.firstWin) return;
                else
                {
                    _tutorialTextView.text = _tutorial.winText[0];
                    _tutorial.firstWin = true;
                }
                break;
            case TutorialEnum.FirsLoseBattlePageLaunch:
                if(_tutorial.firstLose) return;
                else
                {
                    _tutorialTextView.text = _tutorial.loseText[0];
                    _tutorial.firstLose = true;
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(tutorialEnum), tutorialEnum, null);
        }
        nextMessageTutorial.gameObject.SetActive(true);
        Time.timeScale = 0;
        _tutorial.SaveData();
    }
    private void UpdateTextTutorial()
    {
        indexMessage++;
        switch (tutorialEnum)
        {
            case TutorialEnum.FirsHomePageLaunch:
                if (indexMessage < _tutorial.homeText.Length)
                {
                    _tutorialTextView.text = _tutorial.homeText[indexMessage];
                }
                else
                {
                    nextMessageTutorial.gameObject.SetActive(false);
                }
                break;
            case TutorialEnum.FirsMapPageLaunch: 
                if (indexMessage < _tutorial.mapText.Length)
                {
                    _tutorialTextView.text = _tutorial.mapText[indexMessage];
                }
                else
                {
                    nextMessageTutorial.gameObject.SetActive(false);
                }
                break;
            case TutorialEnum.FirsBattlePageLaunch: 
                if (indexMessage < _tutorial.battleText.Length)
                {
                    _tutorialTextView.text = _tutorial.battleText[indexMessage];
                }
                else
                {
                    nextMessageTutorial.gameObject.SetActive(false);
                }
                break;;
            case TutorialEnum.FirsWinBattlePageLaunch: 
                if (indexMessage < _tutorial.winText.Length)
                {
                    _tutorialTextView.text = _tutorial.winText[indexMessage];
                }
                else
                {
                    nextMessageTutorial.gameObject.SetActive(false);
                }
                break;;
            case TutorialEnum.FirsLoseBattlePageLaunch: 
                if (indexMessage < _tutorial.loseText.Length)
                {
                    _tutorialTextView.text = _tutorial.loseText[indexMessage];
                }
                else
                {
                    nextMessageTutorial.gameObject.SetActive(false);
                }
                break;;
            default: throw new ArgumentOutOfRangeException();
        }
        Time.timeScale = 1;
    }
}
