
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class PageManager : MonoBehaviour
{
    public GameConfig stat;

    [SerializeField] private SaveTutorial _tutorial = default;
    [SerializeField] private GameObject First_tutorial = default;
    
    [SerializeField] private GameObject[] page =default;
    [SerializeField] private GameObject[] buttoms = default;
    [SerializeField] private Image bgImage = default; 
    [SerializeField] private Sprite[] bgSprite = default;
    
    [SerializeField] private GameObject NextLVLMainPage = default;
    [SerializeField] private GameObject NextLVlBG = default;
    [SerializeField] private GameObject Chess = default;

    [SerializeField] private Text Text_book = default;
    
    
    private void Start()
    {
        stat.LoadData();
        _tutorial.LoadData();
        Uimanager.ChangeMainResurses(stat, MainResurses.Instance.gold, MainResurses.Instance.energy, MainResurses.Instance.rubin);
        if (!_tutorial.first_tutorial)
        {
            First_tutorial.SetActive(true);
            _tutorial.first_tutorial = true;
            _tutorial.SaveData();
        }
        if (stat.Now_BOOK_XP >= stat.NextLVL_BOOK_XP)
        {
            NextLVLMainPage.SetActive(true);
            NextLVlBG.SetActive(true);
        }
        else
        {
            NextLVLMainPage.SetActive(false);
            NextLVlBG.SetActive(false);
        }
    }
    
    private void FixedUpdate()
    {
        for(int i = 0; i < stat.Ches.Length; i++)
        {
            if (stat.Ches[i]==true)
            {
                Chess.SetActive(true);
                break;
            }
            else
            {
                Chess.SetActive(false);
            }
        }
    }
    public void Enrgy_Plus()
    {
        stat.Now_Energy += 5;
    }

    private void ShowReclama()
    {
        int varity = Random.Range(0, 9);
        if (varity == 7)
        {
            Energy.Instanse.addRevard();
        }
        else if(varity == 8)
        {
            Energy.Instanse.AddАVideo();
        }
        else if (varity == 9)
        {
           Energy.Instanse.Baner(); 
        }
    }
    
    public void BookPage(int indexpage)
    {
        Uimanager.SwitchPage(indexpage, page, buttoms);
        bgImage.sprite = bgSprite[indexpage];
    }

    public void ShopPage(int indexpage)
    {
        Uimanager.SwitchPage(indexpage, page, buttoms);
        bgImage.sprite = bgSprite[indexpage];
    }

    public void Equipment(int indexpage)
    {
        Uimanager.SwitchPage(indexpage, page, buttoms);
        bgImage.sprite = bgSprite[indexpage];
    }
}
