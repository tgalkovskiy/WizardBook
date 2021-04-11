using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField] private HP _Stats = default;
    [SerializeField] private GameObject NoRubin = default;
    public void LitleGold()
    {
        if (_Stats.Rubin >= 60)
        {
            _Stats.Gold += 1000;
            _Stats.Rubin -= 60;
            _Stats.SaveData();
        }
        else
        {
            NoRubin.SetActive(true);
        }
    }

    public void MidleGold()
    {
        if (_Stats.Rubin >= 400)
        {
            _Stats.Gold += 10000;
            _Stats.Rubin -= 400;
            _Stats.SaveData();
        }
        else
        {
            NoRubin.SetActive(true);
        }
    }
    public void BigGold()
    {
        if (_Stats.Rubin >= 3500)
        {
            _Stats.Gold += 100000;
            _Stats.Rubin -= 3500;
            _Stats.SaveData();
        }
        else
        {
            NoRubin.SetActive(true);
        }
    }
    
}
