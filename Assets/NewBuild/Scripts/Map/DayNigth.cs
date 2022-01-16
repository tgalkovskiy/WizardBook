using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class DayNigth : MonoBehaviour
{
    [SerializeField] private Map _map =default;
    [SerializeField] private Material[] Day = default;
    [SerializeField] private Material[] Nigth = default;
    //private int typeSkybox;
    //private int LengSkybox;
    
    private void Awake()
    {
        int random = Random.Range(0, 100);
        if (random <50)
        {
            int random1D = Random.Range(0, Day.Length);
            RenderSettings.skybox = Day[random1D];
            //_map.Skybox = Day[random1D];
        }
        if(random>50)
        {
            int random1N = Random.Range(0, Nigth.Length);
            RenderSettings.skybox = Nigth[random1N];
            //_map.Skybox = Nigth[random1N];
        }
    }
}
