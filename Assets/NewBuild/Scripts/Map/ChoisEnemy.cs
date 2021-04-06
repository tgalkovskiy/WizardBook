using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChoisEnemy : MonoBehaviour
{
    [SerializeField]private Camera camera = default;
    [SerializeField] private Transform posCam = default;
    [SerializeField]private GameObject Player = default;
    [SerializeField]private LoadPanel Load = default;
    [SerializeField] private GameObject LoadGameObj = default;
    [SerializeField]private GameObject Discription = default;
    [SerializeField]private Text Text_Name = default;
    [SerializeField] private HP HP = default; 
    RaycastHit hit;
    Vector3 StartPosCa;
    Quaternion StartQuatCam;
    private bool Touch = false;
    private void Start()
    {
        StartPosCa = this.transform.position;
        StartQuatCam = this.transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !Touch)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Touch = true;
                //Debug.Log(hit.collider.name);
                if (hit.collider.gameObject.GetComponent<StatEnemy>() != null)
                {
                    StatEnemy statEnemy = hit.collider.gameObject.GetComponent<StatEnemy>();
                    Text_Name.text = "Что бы пройти дальше нужно сразиться с:" + "\n" + hit.collider.gameObject.GetComponent<StatEnemy>().Name;
                    HP.NumberEnemy = statEnemy.NumberEnemy;
                    HP.HP_Enemy = statEnemy.HP;
                    HP.Damage = statEnemy.Damage;
                    HP.Gold_enemy = statEnemy.Gold;
                    HP.Exp_enemy = statEnemy.Exp;
                    HP.Rubin_Enemy = statEnemy.Rubin;
                    HP.Chess_Drop = statEnemy.Chess;
                    Player.transform.position = statEnemy.PosPlayer.position;
                    Player.transform.LookAt(hit.collider.gameObject.transform.position);
                    StartCoroutine(DiscriptionE());
                    //this.transform.DOMove(hit.collider.transform.position,2);

                }
            }
        }
        if (Input.touchCount > 0 && !Touch)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = camera.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray, out hit))
            {
                Touch = true;
                //Debug.Log(hit.collider.name);
                if (hit.collider.gameObject.GetComponent<StatEnemy>() != null)
                {
                    StatEnemy statEnemy = hit.collider.gameObject.GetComponent<StatEnemy>();
                    Text_Name.text = "Что бы пройти дальше нужно сразиться с:" + "\n" + hit.collider.gameObject.GetComponent<StatEnemy>().Name;
                    Discription.SetActive(true);
                    HP.NumberEnemy = statEnemy.NumberEnemy;
                    HP.HP_Enemy = statEnemy.HP;
                    HP.Damage = statEnemy.Damage;
                    HP.Gold_enemy = statEnemy.Gold;
                    HP.Exp_enemy = statEnemy.Exp;
                    HP.Rubin_Enemy = statEnemy.Rubin;
                    HP.Chess_Drop = statEnemy.Chess;
                    Player.transform.position = statEnemy.PosPlayer.position;
                    Player.transform.LookAt(hit.collider.gameObject.transform.position);
                    StartCoroutine(DiscriptionE());
                    //this.transform.DOMove(hit.collider.transform.position, 2);

                }
            }
        }
    }


    IEnumerator DiscriptionE()
    {
        this.transform.DOMove((posCam.position), 2);
        this.transform.DORotateQuaternion(Player.transform.rotation, 2);
        yield return new WaitForSeconds(2.5f);
        Discription.SetActive(true);
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
}