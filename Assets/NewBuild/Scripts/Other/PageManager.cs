
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class PageManager : MonoBehaviour
{
    public GameConfig config;

    [SerializeField] private SaveTutorial _tutorial = default;
    [SerializeField] private GameObject First_tutorial = default;
    
    private void Start()
    {
        config.LoadData();
        _tutorial.LoadData();
        ResourcesManager.Instance.Money = config.Gold;
        ResourcesManager.Instance.Rubin = config.Rubin;
        ResourcesManager.Instance.Energy = config.Now_Energy;
        if (!_tutorial.first_tutorial)
        {
            First_tutorial.SetActive(true);
            _tutorial.first_tutorial = true;
            _tutorial.SaveData();
        }
    }
    public void Enrgy_Plus()
    {
        config.Now_Energy += 5;
    }
    
}
