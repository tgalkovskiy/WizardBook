
using UnityEngine;
using UnityEngine.UI;
public class ResourcesManager : MonoBehaviour
{
    [SerializeField]private Text money;
    [SerializeField]private Text energy;
    [SerializeField]private Text rubin;
    public GameConfig config;
    public static ResourcesManager Instance;  
    public int Money
    {
        set => money.text = value.ToString();
    }

    public int Energy
    {
        set => energy.text = value.ToString();
    }

    public int Rubin
    {
        set => rubin.text = value.ToString();
    }
    private void Awake()
    {
        Instance = this;
        config.LoadData();
        Money = config.Gold;
        Rubin = config.Rubin;
        Energy = config.Now_Energy;
    }
    
    public static void OpenWindow(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public static void CloseWindow(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
