using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bion_Shois : MonoBehaviour
{
    [SerializeField] private GameObject[] Terrain = default;
    [SerializeField] private GameObject PanelOf = default;
    [SerializeField] private ChoisEnemy ChoisEnemy;
    public void Chois(int NumberTerrain)
    {
        if (NumberTerrain < Terrain.Length)
        {
            Instantiate(Terrain[NumberTerrain]);
            this.gameObject.SetActive(false);
        }
        else
        {
            PanelOf.SetActive(true);
        }
        ChoisEnemy.Touch = false;
    }
}
