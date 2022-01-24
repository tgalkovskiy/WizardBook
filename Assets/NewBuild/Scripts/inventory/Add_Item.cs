using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Add_Item : MonoBehaviour
{
    [SerializeField] private Button ches = default;
    [SerializeField] private Text countChes;
    [SerializeField] private GameObject Cost = default;
    [SerializeField] private GameObject NoRubin = default;
    [SerializeField] private WeaponManager weaponManager = default;
    [SerializeField] private GameConfig gameConfig;
    private int Chois_War;
    private void Awake()
    {
        countChes.text = gameConfig.ches.ToString();
        ches.onClick.AddListener(SelectChess);
    }
    public void SelectChess()
    {
        Cost.SetActive(true);
    }
    public void OpenChes()
    {
        if(gameConfig.Rubin >= 5 && gameConfig.ches>0)
        {
            gameConfig.Rubin -= 5;
            gameConfig.ches -= 1;
            ResourcesManager.Instance.Rubin = gameConfig.Rubin;
            countChes.text = gameConfig.ches.ToString();
            weaponManager.AddItem(CreateItem());
            Cost.SetActive(false);
        }
        else
        {
            NoRubin.SetActive(true);
        }

    }
    private ItemData CreateItem()
    {
        var data = new ItemData();
        data.isItem = true;
        var typeItem = Random.Range(0, 100);
        var gradeItem = Random.Range(0, 100);
        var chanceResist = Random.Range(0, 100);
        data.lvlItem = Random.Range(gameConfig.LVLPers, gameConfig.LVLPers + 2);
        data.maxLvlItem = data.lvlItem + 4;
        //typeItem
        if (typeItem > 0 && typeItem < 50) data.itemType = ItemType.Weapon;
        if (typeItem > 50 && typeItem < 85) data.itemType = ItemType.Armor;
        if (typeItem > 85) data.itemType = ItemType.Other;
        data.iconItem = Random.Range(0, 2);
        //grade
        if (gradeItem > 0 && gradeItem < 40) data.grade = Grade.Usual;
        if (gradeItem > 40 && gradeItem < 70) data.grade = Grade.Rare;
        if (gradeItem > 70 && gradeItem < 90) data.grade = Grade.Epic;
        if (gradeItem > 90) data.grade = Grade.Legendary;
        //PropertyItem
        //weapon
        if(data.itemType == ItemType.Weapon && data.grade == Grade.Usual)data.damage = 20 + gameConfig.LVLPers * (Random.Range(1, 3));
        if(data.itemType == ItemType.Weapon && data.grade == Grade.Rare) data.damage = 25 + gameConfig.LVLPers * (Random.Range(2, 6));
        if (data.itemType == ItemType.Weapon && data.grade == Grade.Epic)
        {
            data.damage = 30 + gameConfig.LVLPers * Random.Range(3, 9);
        }
        if(data.itemType == ItemType.Weapon && data.grade == Grade.Legendary)
        {
            data.damage = 35 + gameConfig.LVLPers * Random.Range(4, 12);
        }
        //Armor
        if(data.itemType == ItemType.Armor && data.grade == Grade.Usual) data.defence = 10 + gameConfig.LVLPers * (Random.Range(1, 3));
        if (data.itemType == ItemType.Armor && data.grade == Grade.Rare)
        {
            data.defence = 15 + gameConfig.LVLPers * (Random.Range(2, 6));
            if(chanceResist < 50) data.resistPotion = 7;
            if(chanceResist > 50 && chanceResist<80) data.resistCold = 5;
            if(chanceResist>80) data.resistFire = 5;
        }
        if (data.itemType == ItemType.Armor && data.grade == Grade.Epic)
        {
            data.defence = 20 + gameConfig.LVLPers * Random.Range(3, 9);
            if(chanceResist < 50) data.resistPotion = 10;
            if(chanceResist > 50 && chanceResist<80) data.resistCold = 7;
            if(chanceResist>80) data.resistFire = 7;
        }
        if(data.itemType == ItemType.Armor && data.grade == Grade.Legendary)
        {
            data.defence = 25 + gameConfig.LVLPers * Random.Range(2, 6);
            data.hp = 15 + gameConfig.LVLPers * Random.Range(2, 6);
            if(chanceResist < 50) data.resistPotion = 15;
            if(chanceResist > 50 && chanceResist<80) data.resistCold = 10;
            if(chanceResist>80) data.resistFire = 10;
        }
        //other
        if(data.itemType == ItemType.Other && data.grade == Grade.Usual) data.hp = 30 + gameConfig.LVLPers * (Random.Range(1, 3));
        if (data.itemType == ItemType.Other && data.grade == Grade.Rare)
        {
            data.hp = 40 + gameConfig.LVLPers * (Random.Range(2, 6));
            if(chanceResist < 50) data.resistPotion = 12;
            if(chanceResist > 50 && chanceResist<80) data.resistCold = 7;
            if(chanceResist>80) data.resistFire = 7;
        }
        if (data.itemType == ItemType.Other && data.grade == Grade.Epic)
        {
            data.defence = 10 + gameConfig.LVLPers * Random.Range(2, 6);
            data.hp = 50 + gameConfig.LVLPers * Random.Range(3, 9);
            if(chanceResist < 50) data.resistPotion = 15;
            if(chanceResist > 50 && chanceResist<80) data.resistCold = 10;
            if(chanceResist>80) data.resistFire = 10;
        }
        if(data.itemType == ItemType.Armor && data.grade == Grade.Legendary)
        {
            data.defence = 25 + gameConfig.LVLPers * Random.Range(2, 6);
            data.hp = 50 + gameConfig.LVLPers * Random.Range(3, 9);
            if(chanceResist < 50) data.resistPotion = 17;
            if(chanceResist > 50 && chanceResist<80) data.resistCold = 12;
            if(chanceResist>80) data.resistFire = 12;
        }
        data.costUp = data.lvlItem;
        data.costTrade = data.lvlItem * 100;
        return data;
    }
    


    
    
}
