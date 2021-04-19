using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public List<GameObject> Page_tutorial;
    private int Number = 0;
    
    public void Next_page()
    {
        if (Number == Page_tutorial.Count-1)
        {
            Skip();
            Debug.Log(1);
        }
        else
        {
            Page_tutorial[Number].SetActive(false);
            Page_tutorial[Number+1].SetActive(true);
            Number++;
        }
    }
    
    public void Skip()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
