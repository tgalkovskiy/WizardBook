using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bion_Shois : MonoBehaviour
{
    [SerializeField] private GameObject[] Terrain = default;
    [SerializeField] private GameObject PanelOf = default;
    [SerializeField] private ChoisEnemy ChoisEnemy;
    [SerializeField] private Map map_Setting;
    
    [SerializeField] private SaveTutorial _saveTutorial = default;
    [SerializeField] private GameObject Map_tutorial = default;

    private void Start()
    {
        ChoisEnemy.enabled = false;
        _saveTutorial.LoadData();
        if(!_saveTutorial.first_map)
        {
            Map_tutorial.SetActive(true);
            _saveTutorial.first_map = true;
            _saveTutorial.SaveData();
        }
    }

    public void Chois(int NumberTerrain)
    {
        if (NumberTerrain < Terrain.Length)
        {
            Instantiate(Terrain[NumberTerrain]);
            map_Setting.LoadData();
            if (NumberTerrain==0)
            {
                ChoisEnemy.maxEntmy = map_Setting.Number_Max1;
                map_Setting.Now_map = 0;
            }
            if (NumberTerrain==1)
            {
                ChoisEnemy.maxEntmy = map_Setting.Number_Max2;
                map_Setting.Now_map = 1;
            }
            if (NumberTerrain==2)
            {
                ChoisEnemy.maxEntmy = map_Setting.Number_Max3;
                map_Setting.Now_map = 2;
            }
            this.gameObject.SetActive(false);
        }
        else
        {
            PanelOf.SetActive(true);
        }
        ChoisEnemy.enabled = true;
    }
}
