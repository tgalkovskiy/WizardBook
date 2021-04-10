using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ChoisEnemy : MonoBehaviour
{
    [SerializeField] private Camera camera = default;
    [SerializeField] private Transform posCam = default;
    [SerializeField] private GameObject Player = default;
    [SerializeField] private LoadPanel Load = default;
    [SerializeField] private GameObject LoadGameObj = default;
    [SerializeField] private GameObject Discription = default;
    [SerializeField] private Text Text_Name = default;
    [SerializeField] private HP HP = default;
    [SerializeField] private Map MapSetting = default;
    [SerializeField] private GameObject Battle = default;
    RaycastHit hit;
    Vector3 StartPosCa;
    Quaternion StartQuatCam;
    [HideInInspector]public bool Touch = false;
    [HideInInspector] public int maxEntmy = 0;
    private void Start()
    {
        StartPosCa = this.transform.position;
        StartQuatCam = this.transform.rotation;
        //MapSetting.LoadData();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !Touch)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<StatEnemy>() != null)
                {
                    StatEnemy statEnemy = hit.collider.gameObject.GetComponent<StatEnemy>();
                    if (statEnemy.PosGame <= maxEntmy)
                    {
                      Text_Name.text = "Что бы пройти дальше нужно сразиться с:" + "\n" + hit.collider.gameObject.GetComponent<StatEnemy>().Name;
                      Battle.SetActive(true);
                      HP.NumberEnemy = statEnemy.NumberEnemy;
                      HP.HP_Enemy = statEnemy.HP;
                      HP.Damage = statEnemy.Damage;
                      HP.Gold_enemy = statEnemy.Gold;
                      HP.Exp_enemy = statEnemy.Exp;
                      HP.Rubin_Enemy = statEnemy.Rubin;
                      HP.Chess_Drop = statEnemy.Chess;
                      MapSetting.Number_now = statEnemy.PosGame;
                      //MapSetting.Number += 1;
                    }
                    else
                    {
                        Text_Name.text = "Вы должны прежде победить других врагов!";
                        Battle.SetActive(false);
                    }
                    Player.transform.position = statEnemy.PosPlayer.position;
                    Player.transform.LookAt(hit.collider.gameObject.transform.position);
                    StartCoroutine(DiscriptionE());
                }
            }
        }
        if (Input.touchCount > 0 && !Touch)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = camera.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<StatEnemy>() != null)
                {
                    StatEnemy statEnemy = hit.collider.gameObject.GetComponent<StatEnemy>();
                    if (statEnemy.PosGame <= maxEntmy)
                    {
                        Text_Name.text = "Что бы пройти дальше нужно сразиться с:" + "\n" + hit.collider.gameObject.GetComponent<StatEnemy>().Name;
                        Battle.SetActive(true);
                        HP.NumberEnemy = statEnemy.NumberEnemy;
                        HP.HP_Enemy = statEnemy.HP;
                        HP.Damage = statEnemy.Damage;
                        HP.Gold_enemy = statEnemy.Gold;
                        HP.Exp_enemy = statEnemy.Exp;
                        HP.Rubin_Enemy = statEnemy.Rubin;
                        HP.Chess_Drop = statEnemy.Chess;
                        MapSetting.Number_now = statEnemy.PosGame;
                      
                        //MapSetting.Number += 1;
                    }
                    else
                    {
                        Text_Name.text = "Вы должны прежде победить других врагов!";
                        Battle.SetActive(false);
                    }
                    Player.transform.position = statEnemy.PosPlayer.position;
                    Player.transform.LookAt(hit.collider.gameObject.transform.position);
                    StartCoroutine(DiscriptionE());
                }
            }
        }
        Debug.Log(Touch);
    }


    IEnumerator DiscriptionE()
    {
        this.transform.DOMove((posCam.position), 2);
        this.transform.DORotateQuaternion(Player.transform.rotation, 2);
        yield return new WaitForSeconds(2.5f);
        Discription.SetActive(true);
        Touch = true;
    }
    IEnumerator Sleep(GameObject gameObject)
    {
        gameObject.SetActive(false);
        this.transform.DOMove(StartPosCa, 2);
        this.transform.DORotateQuaternion(StartQuatCam, 2);
        yield return new WaitForSeconds(2);
        Touch = false;
    }
    public void Loadgame()
    {
        Load.NumberScene = 3;
        LoadGameObj.SetActive(true);
    }
    public void Back(GameObject gameObject)
    {
        StartCoroutine(Sleep(gameObject));
    }

    public void Menu()
    {
        SceneManager.LoadScene(1);
    }
    
}