using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "Word", menuName = "WrongWord")]
public class WrongWord : ScriptableObject
{
    public class Data
    {
        public List<string> Wrong_Word_Ru;
        public List<string> Wrong_Word_Eng;
        public List<string> Wrong_Word_BEL;
    }

    public List<string> Wrong_Word_Ru;
    public List<string> Wrong_Word_Eng;
    public List<string> Wrong_Word_BEL;

    public void Save_wrong_Word()
    {
         string Path = System.IO.Path.Combine(Application.persistentDataPath, "SaveWrong_word.Json");
         Data data = new Data();
         data.Wrong_Word_Ru = Wrong_Word_Ru;
         data.Wrong_Word_Eng = Wrong_Word_Eng;
         data.Wrong_Word_BEL = Wrong_Word_BEL;
         try
         {
             File.WriteAllText(Path, JsonUtility.ToJson(data));
         }
         catch
         {
             Debug.Log("not Save_wrong_word");
         }
         finally
         {
             Debug.Log("Save_wrong_word Done");
         }
    }

    public void Load_wrong_word()
    {
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "SaveWrong_word.Json");
        if (File.Exists(Path))
        {
            Data data = new Data();
            data = JsonUtility.FromJson<Data>(File.ReadAllText(Path));
            Wrong_Word_Ru = data.Wrong_Word_Ru;
            Wrong_Word_Eng = data.Wrong_Word_Eng;
            Wrong_Word_BEL = data.Wrong_Word_BEL;
        }
        else
        {
            Wrong_Word_Ru.Clear();
            Wrong_Word_Eng.Clear();
            Wrong_Word_BEL.Clear();
        }
    }
    

}
