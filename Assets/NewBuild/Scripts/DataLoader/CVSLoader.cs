
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class CVSLoader : MonoBehaviour
{
    private Action<string> testAction;
    private bool _debug = true;
    private const string url = "https://docs.google.com/spreadsheets/d/*/export?format=csv";
    private string pathToSave;

    private void Start()
    {
        pathToSave = Path.Combine(Application.persistentDataPath, "WordBase.json");
        testAction += SaveWordBase;
        DownloadTable("1jxDV5zff4H_vcZDgogaBBoxNAQ9Z0luRgyGlEJLK7Uw", testAction);
    }

    public void DownloadTable(string sheetId, Action<string> onSheetLoadedAction)
    {
        string actualUrl = url.Replace("*", sheetId);
        StartCoroutine(DownloadRawCvsTable(actualUrl, onSheetLoadedAction));
    }

    private IEnumerator DownloadRawCvsTable(string actualUrl, Action<string> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(actualUrl))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError ||
                request.result == UnityWebRequest.Result.DataProcessingError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                if (_debug)
                {
                    //Debug.Log("Successful download");
                    //Debug.Log(request.downloadHandler.text);
                }
                callback(request.downloadHandler.text);
            }
            
        }
        yield return null;
    }

    public async void SaveWordBase(string data)
    {
        await Task.Run((() =>
        {
            WordDataBase dataBase = new WordDataBase();
            string[] contentLine = data.Split('\n');
            for (int i = 1; i < contentLine.Length; i++)
            {
                string[] contentRow = contentLine[i].Split(',');
                if (contentRow[0] == "1")
                {
                    dataBase.eng1.Add(contentRow[1]);
                    dataBase.rus1.Add(contentRow[2]);
                    dataBase.bel1.Add(contentRow[3]);
                }

                if (contentRow[0] == "2")
                {
                    dataBase.eng2.Add(contentRow[1]);
                    dataBase.rus2.Add(contentRow[2]);
                    dataBase.bel2.Add(contentRow[3]);
                }

                if (contentRow[0] == "3")
                {
                    dataBase.eng3.Add(contentRow[1]);
                    dataBase.rus3.Add(contentRow[2]);
                    dataBase.bel3.Add(contentRow[3]);
                }

                if (contentRow[0] == "4")
                {
                    dataBase.eng4.Add(contentRow[1]);
                    dataBase.rus4.Add(contentRow[2]);
                    dataBase.bel4.Add(contentRow[3]);
                }

                if (contentRow[0] == "5")
                {
                    dataBase.eng5.Add(contentRow[1]);
                    dataBase.rus5.Add(contentRow[2]);
                    dataBase.bel5.Add(contentRow[3]);
                }

                if (contentRow[0] == "6")
                {
                    dataBase.eng6.Add(contentRow[1]);
                    dataBase.rus6.Add(contentRow[2]);
                    dataBase.bel6.Add(contentRow[3]);
                }

                if (contentRow[0] == "7")
                {
                    dataBase.eng7.Add(contentRow[1]);
                    dataBase.rus7.Add(contentRow[2]);
                    dataBase.bel7.Add(contentRow[3]);
                }
            }
            File.WriteAllText(pathToSave, JsonUtility.ToJson(dataBase));
        }));
        
    }
}
[Serializable]
public class WordDataBase
{
    public List<string> eng1 = new List<string>();
    public List<string> rus1 = new List<string>();
    public List<string> bel1 = new List<string>();
    
    public List<string> eng2 = new List<string>();
    public List<string> rus2 = new List<string>();
    public List<string> bel2 = new List<string>();
    
    public List<string> eng3 = new List<string>();
    public List<string> rus3 = new List<string>();
    public List<string> bel3 = new List<string>();
    
    public List<string> eng4 = new List<string>();
    public List<string> rus4 = new List<string>();
    public List<string> bel4 = new List<string>();
    
    public List<string> eng5 = new List<string>();
    public List<string> rus5 = new List<string>();
    public List<string> bel5 = new List<string>();
    
    public List<string> eng6 = new List<string>();
    public List<string> rus6 = new List<string>();
    public List<string> bel6 = new List<string>();
    
    public List<string> eng7 = new List<string>();
    public List<string> rus7 = new List<string>();
    public List<string> bel7 = new List<string>();
}
