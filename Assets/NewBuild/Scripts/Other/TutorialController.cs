
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [SerializeField]private SaveTutorial _tutorial;
    [MultilineAttribute(5)][HeaderAttribute("Description of the tutorial")] [SerializeField]private string[] _tutorialText;
    [SerializeField]private Text _tutorialTextView;
    [SerializeField] private Button nextMessageTutorial;
    private int indexMessage = 0; 
    private void Start()
    {
        _tutorial.LoadData();
        if (_tutorial.first_tutorial) return;
        nextMessageTutorial.gameObject.SetActive(true);
        _tutorial.first_tutorial = true;
        _tutorial.SaveData();
        _tutorialTextView.text = _tutorialText[indexMessage];
        nextMessageTutorial.onClick.AddListener(UpdateTextTutorial);
    }
    private void UpdateTextTutorial()
    {
        indexMessage++;
        if(indexMessage < _tutorialText.Length)
        {
            _tutorialTextView.text = _tutorialText[indexMessage];
        }
        else
        {
            nextMessageTutorial.gameObject.SetActive(false);
        }
    }
}
