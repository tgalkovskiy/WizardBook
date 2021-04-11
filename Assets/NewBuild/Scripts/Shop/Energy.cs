using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.Advertisements;

public class Energy : MonoBehaviour
{
    [SerializeField] private HP _Stats = default;
    [SerializeField] private GameObject NoRubin = default;
    private void Start()
    {
        Advertisement.Initialize("4084815",true);
    }

    public void AddАFree()
    {
        Advertisement.Show();
        _Stats.Now_Energy += 5;
    }

    public void LitleEnrgy()
    {
        if (_Stats.Rubin >= 20)
        {
            _Stats.Now_Energy += 50;
            _Stats.Rubin -= 20;
            _Stats.SaveData();
        }
        else
        {
            NoRubin.SetActive(true);
        }
    }
    public void BigEnrgy()
    {
        if (_Stats.Rubin >= 50)
        {
            _Stats.Now_Energy += 250;
            _Stats.Rubin -= 50;
            _Stats.SaveData();
        }
        else
        {
            NoRubin.SetActive(true);
        }
    }
}
