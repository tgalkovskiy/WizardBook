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
        PosPers();
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
                      Text_Name.text = "\n" + hit.collider.gameObject.GetComponent<StatEnemy>().Name;
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
                        Text_Name.text = "\n" + "Вы должны прежде победить других врагов!";
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
    }

    private void PosEnemy()
    {
        if (MapSetting.Now_map == 0)
        {
            MapSetting.X1 = Player.transform.position.x;
            MapSetting.Y1 = Player.transform.position.y;
            MapSetting.Z1 = Player.transform.position.z;
        }
        else if(MapSetting.Now_map == 1)
        {
            MapSetting.X2 = Player.transform.position.x;
            MapSetting.Y2 = Player.transform.position.y;
            MapSetting.Z2 = Player.transform.position.z;
        }
        else
        {
            MapSetting.X3 = Player.transform.position.x;
            MapSetting.Y3 = Player.transform.position.y;
            MapSetting.Z3 = Player.transform.position.z;
        }
    }

    private void PosPers()
    {
        if (MapSetting.Now_map == 0)
        {
            Player.transform.position = new Vector3(MapSetting.X1, MapSetting.Y1, MapSetting.Z1);
        }
        else if(MapSetting.Now_map == 1)
        {
            Player.transform.position = new Vector3(MapSetting.X2, MapSetting.Y2, MapSetting.Z2);
        }
        else
        {
            Player.transform.position = new Vector3(MapSetting.X3, MapSetting.Y3, MapSetting.Z3);
        }
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
        PosEnemy();
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