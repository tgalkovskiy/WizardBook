
using UnityEngine;
using UnityEngine.UI;

public class UiViewMenu : MonoBehaviour
{
    [SerializeField] private Button playGame;

    private void Awake()
    {
        playGame.onClick.AddListener( (() => SceneController.LoadScene(2)));
    }
}
