using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bion_Shois : MonoBehaviour
{
    [SerializeField] private GameObject[] Terrain = default;
    [SerializeField] private GameObject PanelOf = default;
    public void Chois(int NumberTerrain)
    {
        if (NumberTerrain < Terrain.Length)
        {
            Terrain[NumberTerrain].SetActive(true);
            this.gameObject.SetActive(false);
        }
        else
        {
            PanelOf.SetActive(true);
        }
        
    }
}
