
using System.IO;
using UnityEditor;
using UnityEngine;

public class RemoveSave : MonoBehaviour
{
    [MenuItem("Save/RemoveSaveFolder")]
    static void RemoveSaveFolder()
    {
        string[] filepath = Directory.GetFiles(Application.persistentDataPath);
        foreach (var t in filepath)
        {
            File.Delete(t);
        }
    }
}
