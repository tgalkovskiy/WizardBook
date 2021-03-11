using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManeger : MonoBehaviour
{
    [SerializeField] private Setting Setting  = default;
    [SerializeField] private AudioSource Volume = default;
    [SerializeField] private Slider Volum_Slider = default;

    private void Awake()
    {
        Setting.LoadSetting();
        Volume.volume = Setting._Volume;
        Volum_Slider.value = Setting._Volume;
    }
    public void ChangeVolume()
    {
        Volume.volume = Volum_Slider.value;
        Setting._Volume = Volume.volume;
        Setting.SaveSetting();
    }
    
}
