
using UnityEngine;
using UnityEngine.UI;
public class ResourcesManager : MonoBehaviour
{
    [SerializeField]private Text money;
    [SerializeField]private Text energy;
    [SerializeField]private Text rubin;
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
