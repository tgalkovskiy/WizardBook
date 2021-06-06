using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;
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

    private Text hpstat;
    private Text attackstat;
    private Text deffencestat;
    [SerializeField] private HP hp = default;
    
    public static Item Now_Item = default;
    public List<Item> Item_Data = new List<Item>();
    private void Awake()
    {
        Load_Item();
        Refresh_Item();
    }

    private void Start()
    {
        hpstat = StatPers.Instance.hppers;
        attackstat = StatPers.Instance.attackpers;
        deffencestat = StatPers.Instance.armorpers;
        Refresh_stat();
    }

    public void Select_Item()
    {
        Discription.SetActive(true);
        if (Now_Item.Property_Item[0] == 1)
        {
            Type_Item.text = "Оружие";
        }
        else if(Now_Item.Property_Item[0] == 2)
        {
            Type_Item.text = "Броня";
        }
        else if(Now_Item.Property_Item[0] == 3)
        {
            Type_Item.text = "Украшение";
        }
        //Lvl Item
        Lvl_Item.text = "Уровень: " + Now_Item.Property_Item[3].ToString();
        //Property Item
        string Property_W = "Атака: " + Now_Item.Property_Item[4];
        string Property_A = "Защита: +" + Now_Item.Property_Item[5];
        string Property_O = "Здоровье : +" + Now_Item.Property_Item[8];
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
        Cost_NextLVL_Item.text = "Цена: " + Now_Item.Property_Item[6].ToString();

    }
    public void Equip_Item()
    {
        if(Now_Item.Property_Item[0] == 1)
        {
           hp.NumberSworld = Now_Item.Property_Item[1];
           hp.Property_W[0] = Now_Item.Property_Item[4];
           hp.Property_W[1] = Now_Item.Property_Item[8];
           Sprite_W_G.sprite = Now_Item.Grad_Sprite[Now_Item.Property_Item[2]];
           Sprite_W_I.sprite = Now_Item.Sprite_Weapon[Now_Item.Property_Item[1]];
           hp.Weapon_Grad = Now_Item.Property_Item[2];
           hp.Weapon_Icon = Now_Item.Property_Item[1];
        }
        if(Now_Item.Property_Item[0] == 2)
        {
            hp.Property_A[0] = Now_Item.Property_Item[5];
            hp.Property_A[1] = Now_Item.Property_Item[8];
            Sprite_A_G.sprite = Now_Item.Grad_Sprite[Now_Item.Property_Item[2]];
            Sprite_A_I.sprite = Now_Item.Sprite_Armor[Now_Item.Property_Item[1]];
            hp.Armor_Grad = Now_Item.Property_Item[2];
            hp.Armor_Icon = Now_Item.Property_Item[1];
        }
        if(Now_Item.Property_Item[0] == 3)
        {
            hp.Property_O[0] = Now_Item.Property_Item[8];
            hp.Property_O[1] = Now_Item.Property_Item[4];
            hp.Property_O[2] = Now_Item.Property_Item[5];
            Sprite_O_G.sprite = Now_Item.Grad_Sprite[Now_Item.Property_Item[2]];
            Sprite_O_i.sprite = Now_Item.Sprite_Other[Now_Item.Property_Item[1]];
            hp.Other_Grad = Now_Item.Property_Item[2];
            hp.Other_Icon = Now_Item.Property_Item[1];
        }
        Refresh_stat();
        hp.SaveData();
        Discription.SetActive(false);
    }

    public void LVL_UP_Item()
    {
        if(Now_Item.Property_Item[6] <= hp.Gold)
        {
            if(Now_Item.Property_Item[3] < Now_Item.Property_Item[7])
            {
                Now_Item.Property_Item[3] += 1;
                hp.Gold -= Now_Item.Property_Item[6];
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
                Uimanager.ChangeMainResurses(hp, MainResurses.Instance.gold, MainResurses.Instance.energy, MainResurses.Instance.rubin);
                hp.SaveData();
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
            //Json_SerializeObject json_SerializeObject = new Json_SerializeObject();
            string Data ="";
            for (int k = 0; k < 9; k++)
            {
                Data += Item_Data[i].Property_Item[k].ToString()+"|";
                //json_SerializeObject.Property_Item[k] = Item_Data[i].Property_Item[k];
            }
            //string Item = JsonConvert.SerializeObject(json_SerializeObject);
            save_Item_Class.Inventory_Item[i] = Data;
        }
        try
        {
            File.WriteAllText(Path, JsonUtility.ToJson(save_Item_Class));

        }
        catch
        {

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
                //Json_SerializeObject json_SerializeObject = new Json_SerializeObject();
                //json_SerializeObject = JsonConvert.DeserializeObject<Json_SerializeObject>(save_Item_Class.Inventory_Item[i]);
                string Data_cell =  save_Item_Class.Inventory_Item[i];
                string[] Data = (Data_cell.Split('|')) ;
                for (int k = 0; k < 9; k++)
                {
                    Item_Data[i].Property_Item[k] = int.Parse(Data[k]);
                }
            }
        }
        else
        {
            //Debug.Log("No Save Item");
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
            hp.NumberSworld = 0;
            hp.Property_W[0] = Item_Data[0].Property_Item[4];
            //Sprite_W_G.sprite = Item_Data[0].Grad_Sprite[HP.Weapon_Grad];
            //Sprite_W_I.sprite = Item_Data[0].Sprite_Weapon[HP.Weapon_Icon];
        }
        Sprite_W_G.sprite = Item_Data[0].Grad_Sprite[hp.Weapon_Grad];
        Sprite_W_I.sprite = Item_Data[0].Sprite_Weapon[hp.Weapon_Icon];
        if(hp.Armor_Grad != -1)
        {
            Sprite_A_G.sprite = Item_Data[0].Grad_Sprite[hp.Armor_Grad];
            Sprite_A_I.sprite = Item_Data[0].Sprite_Armor[hp.Armor_Icon];
        }
        if (hp.Other_Grad != -1)
        {
            Sprite_O_G.sprite = Item_Data[0].Grad_Sprite[hp.Other_Grad];
            Sprite_O_i.sprite = Item_Data[0].Sprite_Other[hp.Other_Icon];
        }
        Save_Item();
        hp.SaveData();
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
        hp.Gold += Now_Item.Property_Item[6];
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
                hp.SaveData();
                break;
            }
        }
        
    }
    [Serializable]
    public class Json_SerializeObject
    {
        public int[] Property_Item = new int[9];
    }
    [Serializable]
    public class Save_Item_Class
    {
        public string[] Inventory_Item = new string[20];
    }
    
    private void Refresh_stat()
    {
        hpstat.text ="HP: " + (hp.HP_Gerl + hp.Property_W[1] + hp.Property_A[1] + hp.Property_O[0]).ToString();
        attackstat.text ="Атака: " + (hp.Property_W[0] + hp.Property_O[1]).ToString();
        deffencestat.text = "Защита: " + (hp.Property_A[0] + hp.Property_O[2]).ToString();
    }
}

   

