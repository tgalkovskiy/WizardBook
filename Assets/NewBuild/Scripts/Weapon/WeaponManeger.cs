using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class WeaponManeger : MonoBehaviour
{
    [SerializeField] private Image Sprite_W_G = default;
    [SerializeField] private Image Sprite_W_I = default;
    [SerializeField] private Image Sprite_A_G = default;
    [SerializeField] private Image Sprite_A_I = default;
    [SerializeField] private Image Sprite_O_G = default;
    [SerializeField] private Image Sprite_O_i = default;

    [SerializeField] private GameObject Discription = default;
    [SerializeField] private GameObject MAx_Lvl_Item = default;
    [SerializeField] private GameObject No_money = default;
    [SerializeField] private Text Type_Item = default;
    [SerializeField] private Text Lvl_Item = default;
    [SerializeField] private Text Properti_Item = default;
    [SerializeField] private Text Cost_NextLVL_Item = default;
    [SerializeField] private HP HP = default;
    public static Item Now_Item = default;
    public List<Item> Item_Data = new List<Item>();
    private void Awake()
    {
        Load_Item();
        Refresh_Item();
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
        Discription.SetActive(true);
        if (Now_Item.Property_Item[0] == 1)
        {
            Type_Item.text = "Weapon";
        }
        else if(Now_Item.Property_Item[0] == 2)
        {
            Type_Item.text = "Armor";
        }
        else if(Now_Item.Property_Item[0] == 3)
        {
            Type_Item.text = "Other";
        }
        //Lvl Item
        Lvl_Item.text = "Lvl: " + Now_Item.Property_Item[3].ToString();
        //Property Item
        string Property_W = "Attack: " + Now_Item.Property_Item[4];
        string Property_A = "Deffence: +" + Now_Item.Property_Item[5];
        string Property_O = "HP : +" + Now_Item.Property_Item[8];
        string AllProperty = "";
        if (Now_Item.Property_Item[4] != 0)
        {
            AllProperty += Property_W; 
        }
        if (Now_Item.Property_Item[5] != 0)
        {
            AllProperty += "\n" + Property_A;
        }
        if (Now_Item.Property_Item[8] != 0)
        {
            AllProperty += "\n" + Property_O;
        }
        Properti_Item.text = AllProperty;
        Cost_NextLVL_Item.text = "Cost: " + Now_Item.Property_Item[6].ToString();

    }
    public void Equip_Item()
    {
        if (Now_Item.Property_Item[0] == 1)
        {
           HP.NumberSworld = Now_Item.Property_Item[1];
           HP.Property_W[0] = Now_Item.Property_Item[4];
           HP.Property_W[1] = Now_Item.Property_Item[8];
           Sprite_W_G.sprite = Now_Item.Grad_Sprite[Now_Item.Property_Item[2]];
           Sprite_W_I.sprite = Now_Item.Sprite_Weapon[Now_Item.Property_Item[1]];
           HP.Weapon_Grad = Now_Item.Property_Item[2];
           HP.Weapon_Icon = Now_Item.Property_Item[1];
        }
        if(Now_Item.Property_Item[0] == 2)
        {
            HP.Property_A[0] = Now_Item.Property_Item[5];
            HP.Property_A[1] = Now_Item.Property_Item[8];
            Sprite_A_G.sprite = Now_Item.Grad_Sprite[Now_Item.Property_Item[2]];
            Sprite_A_I.sprite = Now_Item.Sprite_Armor[Now_Item.Property_Item[1]];
            HP.Armor_Grad = Now_Item.Property_Item[2];
            HP.Armor_Icon = Now_Item.Property_Item[1];
        }
        if(Now_Item.Property_Item[0] == 3)
        {
            HP.Property_O[0] = Now_Item.Property_Item[8];
            HP.Property_O[1] = Now_Item.Property_Item[4];
            HP.Property_O[2] = Now_Item.Property_Item[5];
            Sprite_O_G.sprite = Now_Item.Grad_Sprite[Now_Item.Property_Item[2]];
            Sprite_O_i.sprite = Now_Item.Sprite_Other[Now_Item.Property_Item[1]];
            HP.Other_Grad = Now_Item.Property_Item[2];
            HP.Other_Icon = Now_Item.Property_Item[1];
        }
        HP.SaveData();
        Discription.SetActive(false);
    }

    public void LVL_UP_Item()
    {
        if(Now_Item.Property_Item[6] <= HP.Gold)
        {
            if(Now_Item.Property_Item[3] < Now_Item.Property_Item[7])
            {
                Now_Item.Property_Item[3] += 1;
                HP.Gold -= Now_Item.Property_Item[6];
                Now_Item.Property_Item[6] = (int)((float)Now_Item.Property_Item[6]*1.3f);
                if (Now_Item.Property_Item[2] ==0)
                {
                    if(Now_Item.Property_Item[4] != 0)
                    {
                        Now_Item.Property_Item[4] += 2;
                    }
                    if(Now_Item.Property_Item[5] != 0)
                    {
                        Now_Item.Property_Item[5] += 1;
                    }
                    if(Now_Item.Property_Item[8] != 0)
                    {
                        Now_Item.Property_Item[8] += 4;
                    }
                }
                else if(Now_Item.Property_Item[2] == 1)
                {
                    if (Now_Item.Property_Item[4] != 0)
                    {
                        Now_Item.Property_Item[4] += 3;
                    }
                    if (Now_Item.Property_Item[5] != 0)
                    {
                        Now_Item.Property_Item[5] += 2;
                    }
                    if (Now_Item.Property_Item[8] != 0)
                    {
                        Now_Item.Property_Item[8] += 6;
                    }
                }
                else if (Now_Item.Property_Item[2] == 2)
                {
                    if (Now_Item.Property_Item[4] != 0)
                    {
                        Now_Item.Property_Item[4] += 4;
                    }
                    if (Now_Item.Property_Item[5] != 0)
                    {
                        Now_Item.Property_Item[5] += 3;
                    }
                    if (Now_Item.Property_Item[8] != 0)
                    {
                        Now_Item.Property_Item[8] += 8;
                    }
                }
                else if (Now_Item.Property_Item[2] == 3)
                {
                    if (Now_Item.Property_Item[4] != 0)
                    {
                        Now_Item.Property_Item[4] += 5;
                    }
                    if (Now_Item.Property_Item[5] != 0)
                    {
                        Now_Item.Property_Item[5] += 4;
                    }
                    if (Now_Item.Property_Item[8] != 0)
                    {
                        Now_Item.Property_Item[8] += 10;
                    }
                }
                HP.SaveData();
                Save_Item();
                Discription.SetActive(false);
                Equip_Item();
            }
            else
            {
                MAx_Lvl_Item.SetActive(true);
            }
        }
        else
        {
            No_money.SetActive(true);
        }
    }

    public void Save_Item()
    {
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "Save_Item.Json");
        Save_Item_Class save_Item_Class = new Save_Item_Class();
        for (int i = 0; i < Item_Data.Count; i++)
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
            for (int i = 0; i < Item_Data.Count; i++)
            {
                Json_SerializeObject json_SerializeObject = new Json_SerializeObject();
                json_SerializeObject = JsonConvert.DeserializeObject<Json_SerializeObject>(save_Item_Class.Inventory_Item[i]);
                for (int k = 0; k < json_SerializeObject.Property_Item.Length; k++)
                {
                    Item_Data[i].Property_Item[k] = json_SerializeObject.Property_Item[k];
                }
            }
        }
        else
        {
            Debug.Log("No Save Item");
            Item_Data[0].Property_Item[0] = 1;
            Item_Data[0].Property_Item[1] = 0;
            Item_Data[0].Property_Item[2] = 0;
            Item_Data[0].Property_Item[3] = 0;
            Item_Data[0].Property_Item[4] = 30;
            Item_Data[0].Property_Item[5] = 0;
            Item_Data[0].Property_Item[6] = 100;
            Item_Data[0].Property_Item[7] = 7;
            Item_Data[0].Property_Item[8] = 0;
            Refresh_Item();
            HP.NumberSworld = 0;
            HP.Property_W[0] = Item_Data[0].Property_Item[4];
            Save_Item();
            HP.SaveData();
        }
        Sprite_W_G.sprite = Item_Data[0].Grad_Sprite[HP.Weapon_Grad];
        Sprite_W_I.sprite = Item_Data[0].Sprite_Weapon[HP.Weapon_Icon];
        if(HP.Armor_Grad != -1)
        {
            Sprite_A_G.sprite = Item_Data[0].Grad_Sprite[HP.Armor_Grad];
            Sprite_A_I.sprite = Item_Data[0].Sprite_Armor[HP.Armor_Icon];
        }
        if (HP.Other_Grad != -1)
        {
            Sprite_O_G.sprite = Item_Data[0].Grad_Sprite[HP.Other_Grad];
            Sprite_O_i.sprite = Item_Data[0].Sprite_Other[HP.Other_Icon];
        }
    }

    private void Refresh_Item()
    {
        for (int i = 0; i < Item_Data.Count; i++)
        {
            if(Item_Data[i].Property_Item[0] == 0 && i< Item_Data.Count-1)
            {
                if(Item_Data[i+1].Property_Item[0] != 0)
                {
                    for(int k =0; k< Item_Data[i].Property_Item.Length; k++)
                    {
                        Item_Data[i].Property_Item[k] = Item_Data[i + 1].Property_Item[k];
                        Item_Data[i + 1].Property_Item[k] = 0;
                    }
                }
            }
            Item_Data[i].Visulity_Item();
        } 
    }

    public void Cleer_Item()
    {
        HP.Gold += Now_Item.Property_Item[6];
        for (int i =0; i< Now_Item.Property_Item.Length; i++)
        {
            Now_Item.Property_Item[i] = 0;
        }
        Refresh_Item();
        Save_Item();
        Discription.SetActive(false);
    }

    public void Add_Item(int[] Property)
    {
        for(int i = 0; i<Item_Data.Count; i++)
        {
            if(Item_Data[i].Property_Item[0] == 0)
            {
                for(int k = 0; k< Item_Data[i].Property_Item.Length; k++)
                {
                    Item_Data[i].Property_Item[k] = Property[k];
                }
                //Item_Data[i] = item;
                Refresh_Item();
                Save_Item();
                HP.SaveData();
                break;
            }
        }
        
    }

    public class Json_SerializeObject
    {
        public int[] Property_Item = new int[9];
    }
    public class Save_Item_Class
    {
        public string[] Inventory_Item = new string[20];
    }

    public void Bakc(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}

   

