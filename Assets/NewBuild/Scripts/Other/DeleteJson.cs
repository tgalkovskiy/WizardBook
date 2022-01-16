using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DeleteJson : MonoBehaviour
{
    [SerializeField] private GameConfig PersStat;

    private void Start()
    {
        PersStat.LoadData();
        if(PersStat.NextLVL_BOOK_XP == 0.0f)
        {
            File.Delete(System.IO.Path.Combine(Application.persistentDataPath, "SaveBOOK.Json"));
        }
    }
}
