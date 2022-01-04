
using UnityEngine;
using UnityEngine.UI;

public class MagicSchoolView: MonoBehaviour
{
    public Button fire;
    public Button watter;
    public Button ground;
    public Button air;

    public GameObject pageFire;
    public GameObject pageWatter;
    public GameObject pageGround;
    public GameObject pageAir;
    private void Awake()
    {
        fire.onClick.AddListener(ShowSchoolFire);  
        watter.onClick.AddListener(ShowSchoolWatter);
        ground.onClick.AddListener(ShowSchoolGround);
        air.onClick.AddListener(ShowSchoolAir);
    }

    private void ShowSchoolFire()
    {
        pageFire.SetActive(true);
        pageWatter.SetActive(false);
        pageGround.SetActive(false);
        pageAir.SetActive(false);
    }
    private void ShowSchoolWatter()
    {
        pageFire.SetActive(false);
        pageWatter.SetActive(true);
        pageGround.SetActive(false);
        pageAir.SetActive(false);
    }
    private void ShowSchoolGround()
    {
        pageFire.SetActive(false);
        pageWatter.SetActive(false);
        pageGround.SetActive(true);
        pageAir.SetActive(false);
    }
    private void ShowSchoolAir()
    {
        pageFire.SetActive(false);
        pageWatter.SetActive(false);
        pageGround.SetActive(false);
        pageAir.SetActive(true);
    }
}
