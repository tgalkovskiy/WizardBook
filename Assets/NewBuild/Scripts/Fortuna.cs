using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fortuna : MonoBehaviour
{
   [SerializeField] private GameObject Whele;
   [SerializeField] private GameObject WindowGOBJ;
   
   [SerializeField] private Text Discription_text;
   [SerializeField] private float Speed;
   [SerializeField] private HP StatPers;
   private int NumberScene = 1;
    private void Awake()
    {
        Speed += Random.Range(0, 6);
    }
    private void Update()
    {
        Whele.transform.Rotate(Vector3.forward*Speed);
        if (Speed > 0)
        {
            Speed -= Time.deltaTime;
        }
        if (Speed < 0)
        {
            Speed = 0;
            Debug.Log(Whele.transform.eulerAngles.z);
            CorrectAngle(Whele.transform.eulerAngles.z);
        }
       
    }

    private void CorrectAngle(float angle)
    {
        Vector3 FinalAngle = Vector3.zero;
        string Discription_Window = "";
        if(angle<=22.5f && angle > 337.5f)
        {
            FinalAngle = new Vector3(0, 0, 0);
            NumberScene = 1;
            Discription_Window = "Поздравляю, большая удача, вы находите много ресурсов!!!";
        }
        else if(angle>22.5f && angle<= 62.5f)
        {
            FinalAngle = new Vector3(0, 0, 45);
            StatPers.NumberEnemy = 1;
            NumberScene = 3;
            Discription_Window = "Вас ожидает битва с Свином!";
            Debug.Log("Pig");
        } 
        else if(angle >62.5f && angle <= 112.5f)
        {
            FinalAngle = new Vector3(0, 0, 90);
            Discription_Window = "К сожалению неудача, вы теряете ресурсы!";
            NumberScene = 1;
        }
        else if(angle > 112.5f && angle <= 157.5f)
        {
            FinalAngle = new Vector3(0, 0, 135);
            StatPers.NumberEnemy = 0;
            NumberScene = 3;
            Discription_Window = "Вас ожидает битва с Омномникумом!";
            Debug.Log("Spawn");
        }
        else if(angle > 157.5f && angle <= 202.5f)
        {
            FinalAngle = new Vector3(0, 0, 180);
            StatPers.NumberEnemy = 2;
            NumberScene = 3;
            Discription_Window = "Вас ожидает битва с Усакулой!";
            Debug.Log("Usakula");
        }
        else if(angle > 202.5f && angle <= 247.5f)
        {
            FinalAngle = new Vector3(0, 0, 225);
            NumberScene = 1;
            Discription_Window = "Поздравляю, удача, вы находите ресурсы!!!";
        }
        else if(angle > 247.5f && angle <= 292.5f)
        {
            FinalAngle = new Vector3(0, 0, 270);
            StatPers.NumberEnemy = 0;
            NumberScene = 3;
            Discription_Window = "Вас ожидает битва с Омномникумом!";
            Debug.Log("Spawn");
        }
        else if(angle > 292.5f && angle <= 337.5f)
        {
            FinalAngle = new Vector3(0, 0, 315);
            StatPers.NumberEnemy = 0;
            NumberScene = 3;
            Discription_Window = "Вас ожидает битва с Омномникумом!";
            Debug.Log("Spawn");
        }
        Whele.transform.DORotate(FinalAngle,1f);
        StartCoroutine(Window(Discription_Window));
    }
    IEnumerator Window(string Discription)
    {
        yield return new WaitForSeconds(1.5f);
        Discription_text.text = Discription;
        WindowGOBJ.SetActive(true);
    }
    public void OK()
    {
        SceneManager.LoadScene(NumberScene);
    }
}
