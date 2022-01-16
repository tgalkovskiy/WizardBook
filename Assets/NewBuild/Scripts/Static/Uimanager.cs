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
            if (i == index)
            {
                page[i].SetActive(true);
            }
        }
    }

    public static void ChangeMainResurses(GameConfig stat, Text money, Text energy, Text rubin)
    {
        money.text = stat.Gold.ToString();
        energy.text = stat.Now_Energy.ToString();
        rubin.text = stat.Rubin.ToString();
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
