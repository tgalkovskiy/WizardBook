using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainResurses : MonoBehaviour
{
    public Text gold;
    public Text energy;
    public Text rubin;
    public static MainResurses Instance;

    private void Awake()
    {
        Instance = this;
    }
}
