﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bion_Shois : MonoBehaviour
{
    [SerializeField] private GameObject[] Terrain = default;
    [SerializeField] private GameObject PanelOf = default;
    [SerializeField] private ChoisEnemy ChoisEnemy;
    [SerializeField] private Map map_Setting;
    [SerializeField] private HP _hp =default;

    [SerializeField] private Image _map2 = default;
    [SerializeField] private Image _map3 = default;

    [SerializeField] private Sprite[] _iconMap = default;
    [SerializeField] private GameObject[] _text = default;

    [SerializeField] private SaveTutorial _saveTutorial = default;
    [SerializeField] private GameObject Map_tutorial = default;
    
    

    private void Start()
    {
        map_Setting.LoadData();
        ChoisEnemy.enabled = false;
        _saveTutorial.LoadData();
        if(!_saveTutorial.first_map)
        {
            Map_tutorial.SetActive(true);
            _saveTutorial.first_map = true;
            _saveTutorial.SaveData();
        }

        if (_hp.LVLBooK >= 3)
        {
            _map2.sprite = _iconMap[0];
            _text[0].SetActive(false);
        }

        if (_hp.LVLBooK >= 6)
        {
            _map3.sprite = _iconMap[1];
            _text[1].SetActive(false);
        }
    }

    public void Chois(int NumberTerrain)
    {
        if (NumberTerrain < Terrain.Length)
        {
            if (NumberTerrain==0)
            {
                ChoisEnemy.maxEntmy = map_Setting.Number_Max1;
                map_Setting.Now_map = 0;
                ChoisEnemy.enabled = true;
                this.gameObject.SetActive(false);
                Instantiate(Terrain[NumberTerrain]);
                map_Setting.LoadData();
            }
            if (NumberTerrain==1 && _hp.LVLBooK>=3)
            {
                ChoisEnemy.maxEntmy = map_Setting.Number_Max2;
                map_Setting.Now_map = 1;
                ChoisEnemy.enabled = true;
                this.gameObject.SetActive(false);
                Instantiate(Terrain[NumberTerrain]);
                map_Setting.LoadData();
            }
            if (NumberTerrain==2 && _hp.LVLBooK>=6)
            {
                ChoisEnemy.maxEntmy = map_Setting.Number_Max3;
                map_Setting.Now_map = 2;
                ChoisEnemy.enabled = true;
                this.gameObject.SetActive(false);
                Instantiate(Terrain[NumberTerrain]);
                map_Setting.LoadData();
            }
        }
        else
        {
            PanelOf.SetActive(true);
        }
        
    }
}
