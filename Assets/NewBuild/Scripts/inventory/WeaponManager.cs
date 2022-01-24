using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class SaveItemClass
{
    public ItemData[] equipData = new ItemData[3];
    public ItemData[] inventoryData = new ItemData[18];
}
public class WeaponManager : MonoBehaviour
{
    public DressedItem dressedItem;
    [SerializeField] private GameObject Discription = default;
    [SerializeField] private GameObject MAx_Lvl_Item = default;
    [SerializeField] private GameObject No_money = default;
    [SerializeField] private Text typeItemText = default;
    [SerializeField] private Text lvlItemText = default;
    [SerializeField] private Text propertyItem = default;
    [SerializeField] private Text costFromNextLvlItem = default;
    [SerializeField] private GameConfig gameConfig = default;
    public static Item selectItem = default;
    public List<Item> itemInventory = new List<Item>();
    private void Awake()
    {
        LoadDataItem();
    }
    private void Start()
    {
        RefreshItem();
    }

    public void SelectItem()
    {
        if(!selectItem.data.isItem) return;
        Discription.SetActive(true);
        propertyItem.text = string.Empty;
        typeItemText.text = selectItem.data.itemType switch
        {
            ItemType.Weapon => "ПОСОХ ИМОРТА",
            ItemType.Armor => "ЛАТЫ ИКУНА",
            ItemType.Other => "КОЛЬЦА ХАНАГА",
            _ => typeItemText.text
        };
        typeItemText.text +="\n"+ selectItem.data.grade switch
        {
            Grade.Usual => "ОБЫЧНЫЙ",
            Grade.Rare => "РЕДКИЙ",
            Grade.Epic => "ЭПИЧЕСКИЙ",
            Grade.Legendary => "ЛЕГЕНДАРНЫЙ",
            _ => typeItemText.text
        };
        lvlItemText.text = $"УРОВЕНЬ ПРЕДМЕТА: {selectItem.data.lvlItem}\nМАКСИМАЛЬНЫЙ УРОВЕНЬ:" + $"{selectItem.data.maxLvlItem}";
        switch (selectItem.data.itemType)
        {
            case ItemType.Weapon:
                propertyItem.text = $"АТАКА: {selectItem.data.damage}";
                break;
            case ItemType.Armor:
            {
                propertyItem.text = $"БРОНЯ: {selectItem.data.defence}";
                if(selectItem.data.hp!=0)propertyItem.text+= $"\nНР: {selectItem.data.hp}";
                if(selectItem.data.resistPotion!=0) propertyItem.text+= $"\n СОПРОТИВЛЕНИЕ ЯДУ: {selectItem.data.resistPotion}";
                if(selectItem.data.resistCold!=0) propertyItem.text+= $"\n СОПРОТИВЛЕНИЕ ХОЛОДУ: {selectItem.data.resistCold}";
                if(selectItem.data.resistFire!=0) propertyItem.text+= $"\n СОПРАТИВЛЕНИЕ ОГНЮ: {selectItem.data.resistFire}";
                break;
            }
            case ItemType.Other:
            {
                if(selectItem.data.defence!=0)propertyItem.text+= $"\nБРОНЯ: {selectItem.data.defence}";
                if(selectItem.data.hp!=0)propertyItem.text+= $"\nНР: {selectItem.data.hp}";
                if(selectItem.data.resistPotion!=0) propertyItem.text+= $"\n СОПРОТИВЛЕНИЕ ЯДУ: {selectItem.data.resistPotion}";
                if(selectItem.data.resistCold!=0) propertyItem.text+= $"\n СОПРОТИВЛЕНИЕ ХОЛОДУ: {selectItem.data.resistCold}";
                if(selectItem.data.resistFire!=0) propertyItem.text+= $"\n СОПРОТИВЛЕНИЕ ОГНЮ: {selectItem.data.resistFire}";
                break;
            }
        }

        costFromNextLvlItem.text = $"ЦЕНА УЛУЧШЕНИЯ: {selectItem.data.costUp} МОНЕТ\nЦЕНА ПРОДАЖИ: {selectItem.data.costTrade} МОНЕТ";

    }
    public void EquipItem()
    {
        selectItem.data = dressedItem.EquipItem(selectItem);
        RefreshItem();
        SaveDataItem();
        gameConfig.SaveData();
        Discription.SetActive(false);
    }
    public void LVL_UP_Item()
    {
        if(selectItem.Property_Item[6] <= gameConfig.Gold)
        {
            if(selectItem.Property_Item[3] < selectItem.Property_Item[7])
            {
                selectItem.Property_Item[3] += 1;
                gameConfig.Gold -= selectItem.Property_Item[6];
                selectItem.Property_Item[6] = (int)((float)selectItem.Property_Item[6]*1.3f);
                if (selectItem.Property_Item[2] ==0)
                {
                    if(selectItem.Property_Item[4] != 0)
                    {
                        selectItem.Property_Item[4] += 2;
                    }
                    if(selectItem.Property_Item[5] != 0)
                    {
                        selectItem.Property_Item[5] += 1;
                    }
                    if(selectItem.Property_Item[8] != 0)
                    {
                        selectItem.Property_Item[8] += 4;
                    }
                }
                else if(selectItem.Property_Item[2] == 1)
                {
                    if (selectItem.Property_Item[4] != 0)
                    {
                        selectItem.Property_Item[4] += 3;
                    }
                    if (selectItem.Property_Item[5] != 0)
                    {
                        selectItem.Property_Item[5] += 2;
                    }
                    if (selectItem.Property_Item[8] != 0)
                    {
                        selectItem.Property_Item[8] += 6;
                    }
                }
                else if (selectItem.Property_Item[2] == 2)
                {
                    if (selectItem.Property_Item[4] != 0)
                    {
                        selectItem.Property_Item[4] += 4;
                    }
                    if (selectItem.Property_Item[5] != 0)
                    {
                        selectItem.Property_Item[5] += 3;
                    }
                    if (selectItem.Property_Item[8] != 0)
                    {
                        selectItem.Property_Item[8] += 8;
                    }
                }
                else if (selectItem.Property_Item[2] == 3)
                {
                    if (selectItem.Property_Item[4] != 0)
                    {
                        selectItem.Property_Item[4] += 5;
                    }
                    if (selectItem.Property_Item[5] != 0)
                    {
                        selectItem.Property_Item[5] += 4;
                    }
                    if (selectItem.Property_Item[8] != 0)
                    {
                        selectItem.Property_Item[8] += 10;
                    }
                }
                //ResourcesManager.ChangeMainResurses(gameConfig, MainResurses.Instance.gold, MainResurses.Instance.energy, MainResurses.Instance.rubin);
                gameConfig.SaveData();
                SaveDataItem();
                Discription.SetActive(false);
                EquipItem();
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

    private void SaveDataItem()
    {
        var path = Path.Combine(Application.persistentDataPath, "Item.Json");
        var saveItemClass = new SaveItemClass();
        for (int i = 0; i < itemInventory.Count; i++)
        {
            saveItemClass.inventoryData[i] = itemInventory[i].data;
        }
        saveItemClass.equipData[0] = dressedItem.weaponItem.data;
        saveItemClass.equipData[1] = dressedItem.armorItem.data;
        saveItemClass.equipData[2] = dressedItem.otherItem.data;
        File.WriteAllText(path, JsonUtility.ToJson(saveItemClass));
    }
    private void LoadDataItem()
    {
        var path = Path.Combine(Application.persistentDataPath, "Item.Json");
        if (File.Exists(path))
        {
            var saveItemClass = new SaveItemClass();
            saveItemClass = JsonUtility.FromJson<SaveItemClass>(File.ReadAllText(path));
            for (int i = 0; i < itemInventory.Count; i++)
            {
                itemInventory[i].data = saveItemClass.inventoryData[i];
            }
            dressedItem.weaponItem.data = saveItemClass.equipData[0];
            dressedItem.armorItem.data = saveItemClass.equipData[1];
            dressedItem.otherItem.data = saveItemClass.equipData[2];
        }
        else
        {
            itemInventory[0].data = new ItemData()
            {
                isItem = true,
                itemType = ItemType.Weapon,
                grade = Grade.Usual,
                lvlItem = 1,
                maxLvlItem = 5,
                damage = 30,
                defence = 0,
                hp = 0,
                costUp = 100
            };
            itemInventory[0].data = dressedItem.EquipItem(itemInventory[0]);
            gameConfig.NumberSworld = 0;
        }
        RefreshItem();
        dressedItem.UpdateStatus();
        SaveDataItem();
        gameConfig.SaveData();
    }

    private void RefreshItem()
    {
        for(int i = 0; i < itemInventory.Count; i++)
        {
            /*if(!itemInventory[i].data.isItem)
            {
                if(itemInventory[i+1].data.isItem)
                {
                    Debug.Log(1);
                    //ItemData[i].data = ItemData[i + 1].data;
                    //ItemData[i + 1].data.isItem = false;
                    /*for(int k =0; k< ItemData[i].Property_Item.Length; k++)
                    {
                        ItemData[i].Property_Item[k] = ItemData[i + 1].Property_Item[k];
                        ItemData[i + 1].Property_Item[k] = 0;
                    }#1#
                }
            }*/
            itemInventory[i].VisualiseItem();
        }
        dressedItem.weaponItem.VisualiseItem();
        dressedItem.armorItem.VisualiseItem();
        dressedItem.otherItem.VisualiseItem();
    }

    public void ClearItem()
    {
        gameConfig.Gold += selectItem.data.costUp;
        ResourcesManager.Instance.Money = gameConfig.Gold;
        selectItem.data.isItem = false;
        RefreshItem();
        SaveDataItem();
        Discription.SetActive(false);
    }
    public void AddItem(ItemData data)
    {
        foreach (var t in itemInventory)
        {
            if(!t.data.isItem)
            {
                t.data = data;
                RefreshItem();
                SaveDataItem();
                gameConfig.SaveData();
                break;
            }
        }
    }
}

   

