using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    [SerializeField] private HP _Stats = default;
    [SerializeField] private GameObject NoRubin = default;
    [SerializeField] private Text Error = default;
    public static Energy Instanse;

    private void Awake()
    {
        Instanse = this;
    }

    private void Start()
    {
        Advertisement.Initialize("4084755", true);
    }

    public void AddАFreeVideo()
    {
        Advertisement.Show("video");
        _Stats.Now_Energy += 5;
    }
    public void AddАVideo()
    {
        Advertisement.Show("video");
    }

    public void addRevard()
    {
        Advertisement.Show("rewardedVideo");
    }
    public void Baner()
    {
        Advertisement.Show("Baner");
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
