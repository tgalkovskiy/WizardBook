using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SettingPreset", menuName = "SettingGame")]
public class Setting : ScriptableObject
{
    public class SettingData
    {
        public float Volume;
    }
    public float _Volume;
    private void Awake()
    {
        LoadSetting();
    }
    public void SaveSetting()
    {
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "SaveSetting.Json");
        SettingData settingData = new SettingData();
        settingData.Volume = _Volume;
        try
        {
            File.WriteAllText(Path, JsonUtility.ToJson(settingData));
        }
        catch
        {
            Debug.Log("not SaveSetting");
        }
        finally
        {
            Debug.Log("Save Done Setting");
        }
    }
    public void LoadSetting()
    {
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "SaveSetting.Json");
        if (File.Exists(Path))
        {
            SettingData settingData = new SettingData();
            settingData = JsonUtility.FromJson<SettingData>(File.ReadAllText(Path));
            _Volume = settingData.Volume;
        }
        else
        {
            Debug.Log("No SaveSetting");
            _Volume = 1;
        }
    }
}
