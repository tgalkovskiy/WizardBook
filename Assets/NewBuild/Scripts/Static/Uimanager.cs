using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class Uimanager : MonoBehaviour
{
    public static void SwitchPage(int index, GameObject[] page, GameObject[] buttoms)
    {
        for (int i = 0; i < page.Length; i++)
        {
            page[i].SetActive(false);
            buttoms[i].transform.DOScale(1.0f, 0.4f);
            if (i == index)
            {
                page[i].SetActive(true);
                buttoms[i].transform.DOScale(1.3f, 0.4f);
            }
        }
    }

    public static void ChangeMainResurses(HP stat, Text money, Text energy, Text rubin)
    {
        if (money != null)
        {
            money.text = stat.Gold.ToString();
        }
        if (energy != null)
        {
            energy.text = stat.Now_Energy.ToString();
        }

        if (rubin != null)
        {
            rubin.text = stat.Rubin.ToString();
        }
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
