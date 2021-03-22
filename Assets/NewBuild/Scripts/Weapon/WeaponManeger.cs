using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;


public class WeaponManeger : MonoBehaviour
{
    //public List<GameObject> Item_GOJ = default;
    //public Transform[] posCell;
    public static Item Now_Item = default;
    public Item[] Item_Data;
    private void Awake()
    {
        //for (int i = 0; i < Item_GOJ.Count; i++)
        //{
        //    Item_Data.Add(Item_GOJ[i].GetComponent<Item>());
        //}
        Load_Item();
    }
    private void Start()
    {
        Refresh_Item();
        //Item_Data = Item_Data.OrderBy(x => x.Property_Item[2]).ToList<Item>();
        //var A = Item_Data.OrderByDescending(x => x.Property_Item[2]).ToList();
        //for (int i = 0; i < Item_Data.Count; i++)
        //{
        //    Debug.Log(A[i].Property_Item[2]);
        //}
        ////var orderedNumbers = from i in Grad_Index
        ////                     orderby i descending
        ////                     select i;
        ////foreach (int i in orderedNumbers)
        ////{
        ////    Debug.Log(i);
        ////}

    }
    public void Select_Item()
    {
        
    }
    
    public void Save_Item()
    {
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "Save_Item.Json");
        Save_Item_Class save_Item_Class = new Save_Item_Class();
        for(int i =0; i< Item_Data.Length; i++)
        {
            Json_SerializeObject json_SerializeObject = new Json_SerializeObject();
            for (int k = 0; k < json_SerializeObject.Property_Item.Length; k++)
            {
                json_SerializeObject.Property_Item[k] = Item_Data[i].Property_Item[k];
            }
            string Item = JsonConvert.SerializeObject(json_SerializeObject);
            save_Item_Class.Inventory_Item[i] = Item;
        }
        try
        {
            File.WriteAllText(Path, JsonUtility.ToJson(save_Item_Class));
        }
        catch
        {
            Debug.Log("not Save Item");
        }
        finally
        {
            Debug.Log("Save Done Item");
        }
    }
    public void Load_Item()
    {
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "Save_Item.Json");
        if (File.Exists(Path))
        {
            Save_Item_Class save_Item_Class = new Save_Item_Class();
            save_Item_Class = JsonUtility.FromJson<Save_Item_Class>(File.ReadAllText(Path));
            for(int i =0; i< Item_Data.Length; i++)
            {
                Json_SerializeObject json_SerializeObject = new Json_SerializeObject();
                json_SerializeObject = JsonConvert.DeserializeObject<Json_SerializeObject>(save_Item_Class.Inventory_Item[i]);
                for(int k =0; k< json_SerializeObject.Property_Item.Length; k++)
                {
                    Item_Data[i].Property_Item[k] = json_SerializeObject.Property_Item[k];
                }
            }
        }
        else
        {
            Debug.Log("No Save Item");
        }
    }

    private void Refresh_Item()
    {
        Array.Sort(Item_Data);
        //var A = Item_Data.OrderByDescending(x => x.Property_Item[2]).ToList();
        //Item_Data.Clear();
        //Debug.Log(Item_Data.Count);
        //Item_Data.AddRange(A);
        //Debug.Log(Item_Data.Count);
        //for (int i = 0; i < A.Count; i++)
        //{
        //    Item_GOJ[i].GetComponent<Item>().Property_Item[2] = A[i].Property_Item[2];
        //    Item_GOJ[i].GetComponent<Item>().Visulity_Item();
        //    Debug.Log(A[i].Property_Item[2]);
        //    Item_Data.Add(A[i]);
        //    Debug.Log(Item_Data[i].Property_Item[2]);
        //    Debug.Log(A[i].Property_Item[2]);
        //    Debug.Log("До " + Item_Data[i].Property_Item[2]);
        //    Item_Data[i] = A[i];
        //    Debug.Log(A[i].Property_Item[2]);
        //    for (int k = 0; k < 7; k++)
        //    {
        //        Item_Data[i].Property_Item[k] = A[i].Property_Item[k];
        //    }
        //    Item_Data[i].Property_Item[2] = 1;
        //    //Debug.Log("После " + Item_Data[i].Property_Item[2]);
        //    /
        //    Debug.Log(Item_Data[i].Property_Item[2]);
        //    Item_Data.
        //    Item_Data[i].Visulity_Item();
        }

    }

    public class Json_SerializeObject
    {
        public int[] Property_Item = new int[7];
    }
    public class Save_Item_Class
    {
        public string[] Inventory_Item = new string[20];
    }

   

