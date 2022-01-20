using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_Item : MonoBehaviour
{
    [SerializeField] private GameObject[] Chess = default;
    [SerializeField] private GameObject Cost = default;
    [SerializeField] private GameObject NoRubin = default;
    [SerializeField] private WeaponManager weaponManager = default;
    [SerializeField] private GameConfig gameConfig;
    private int Chois_War;
    private void Awake()
    {
       for(int i=0; i < Chess.Length; i++)
       {
            if (gameConfig.Ches[i])
            {
                Chess[i].SetActive(true);
            } 
       } 

    }
    public void SelectChess(int Chois)
    {
        Cost.SetActive(true);
        Chois_War = Chois;
    }
    public void OpenChes()
    {
        if(gameConfig.Rubin >= 5)
        {
            gameConfig.Rubin -= 5;
            weaponManager.AddItem(CreateItem());
            gameConfig.Ches[Chois_War] = false;
            Chess[Chois_War].SetActive(false);
            Cost.SetActive(false);
            Uimanager.ChangeMainResurses(gameConfig, MainResurses.Instance.gold, MainResurses.Instance.energy, MainResurses.Instance.rubin);
        }
        else
        {
            NoRubin.SetActive(true);
        }

    }
    public void Back(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
    private ItemData CreateItem()
    {
        var data = new ItemData();
        data.isItem = true;
        var typeItem = Random.Range(0, 100);
        var gradeItem = Random.Range(0, 100);
        data.lvlItem = Random.Range(gameConfig.LVLPers, gameConfig.LVLPers + 4);
        data.maxLvlItem = data.lvlItem + 4;
        //typeItem
        if(typeItem>0 && typeItem < 45) data.itemType = ItemType.Weapon;
        if(typeItem>40 && typeItem < 75) data.itemType = ItemType.Armor;
        if(typeItem>75) data.itemType = ItemType.Other;
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
            data.hp = 5 + gameConfig.LVLPers * Random.Range(2, 6);
        }
        if(data.itemType == ItemType.Weapon && data.grade == Grade.Legendary)
        {
            data.damage = 35 + gameConfig.LVLPers * Random.Range(4, 12);
            data.hp = 10 + gameConfig.LVLPers * Random.Range(3, 9);
        }
        //Armor
        if(data.itemType == ItemType.Armor && data.grade == Grade.Usual) data.defence = 10 + gameConfig.LVLPers * (Random.Range(1, 3));
        if(data.itemType == ItemType.Armor && data.grade == Grade.Rare) data.defence = 15 + gameConfig.LVLPers * (Random.Range(2, 6));
        if (data.itemType == ItemType.Armor && data.grade == Grade.Epic)
        {
            data.defence = 20 + gameConfig.LVLPers * Random.Range(3, 9);
            data.hp = 10 + gameConfig.LVLPers * Random.Range(2, 6);
        }
        if(data.itemType == ItemType.Armor && data.grade == Grade.Legendary)
        {
            data.defence = 25 + gameConfig.LVLPers * Random.Range(2, 6);
            data.hp = 15 + gameConfig.LVLPers * Random.Range(2, 6);
        }
        //other
        if(data.itemType == ItemType.Other && data.grade == Grade.Usual) data.hp = 30 + gameConfig.LVLPers * (Random.Range(1, 3));
        if(data.itemType == ItemType.Other && data.grade == Grade.Rare) data.hp = 40 + gameConfig.LVLPers * (Random.Range(2, 6));
        if (data.itemType == ItemType.Other && data.grade == Grade.Epic)
        {
            data.defence = 10 + gameConfig.LVLPers * Random.Range(2, 6);
            data.hp = 50 + gameConfig.LVLPers * Random.Range(3, 9);
        }
        if(data.itemType == ItemType.Armor && data.grade == Grade.Legendary)
        {
            data.defence = 25 + gameConfig.LVLPers * Random.Range(2, 6);
            data.hp = 50 + gameConfig.LVLPers * Random.Range(3, 9);
            data.damage = 10 + gameConfig.LVLPers * Random.Range(3, 9);
        }
        data.costUp = data.lvlItem;
        data.costTrade = data.lvlItem * 100;
        return data;
    }
    


    
    
}
