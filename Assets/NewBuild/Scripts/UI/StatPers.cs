using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatPers : MonoBehaviour
{
    public Text hppers;
    public Text attackpers;
    public Text armorpers;
    public static StatPers Instance;
    
    private void Awake()
    {
        Instance = this;
    }
}
