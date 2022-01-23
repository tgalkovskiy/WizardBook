
using System;
using UnityEngine;
using UnityEngine.UI;

public class DressedItem : MonoBehaviour
{
    public GameConfig config;
    public Text lvlPerson;
    public Text hpPerson;
    public Text defencePerson;
    public Text attackPerson;
    public Text resistPotion;
    public Text resistCold;
    public Text resistFire;
    public Item weaponItem;
    public Item armorItem;
    public Item otherItem;

    public ItemData EquipItem(Item item)
    {
        var newData = new ItemData()
        {
            isItem = true,
            itemType = item.data.itemType,
            grade = item.data.grade,
            iconItem = item.data.iconItem,
            lvlItem = item.data.lvlItem,
            maxLvlItem = item.data.maxLvlItem,
            damage = item.data.damage,
            defence = item.data.defence,
            hp = item.data.hp,
            costUp = item.data.costUp,
            costTrade = item.data.costTrade
        };
        var oldData = new ItemData();
        switch(newData.itemType)
        {
            case ItemType.Weapon: ReturnData(weaponItem, oldData); weaponItem.data = newData; break;
            case ItemType.Armor: ReturnData(armorItem, oldData); armorItem.data = newData; break;
            case ItemType.Other: ReturnData(otherItem, oldData); otherItem.data = newData; break;
            default: throw new ArgumentOutOfRangeException();
        }
        weaponItem.VisualiseItem();
        armorItem.VisualiseItem();
        otherItem.VisualiseItem();
        UpdateStatus();
        return oldData;
    }
    
    private void ReturnData(Item item, ItemData data)
    {
        if(!item.data.isItem)return;
        Debug.Log(1);
        data.isItem = true;
        data.itemType = item.data.itemType;
        data.grade = item.data.grade;
        data.iconItem = item.data.iconItem;
        data.lvlItem = item.data.lvlItem;
        data.maxLvlItem = item.data.maxLvlItem;
        data.damage = item.data.damage;
        data.defence = item.data.defence;
        data.hp = item.data.hp;
        data.costUp = item.data.costUp;
        data.costTrade = item.data.costTrade;
    }

    public void UpdateStatus()
    {
        config.damagePerson = weaponItem.data.damage;
        attackPerson.text =$"АТАКА: {config.damagePerson}";
        
        config.defencePerson = armorItem.data.defence;
        config.defencePerson += otherItem.data.defence;
        defencePerson.text =$"БРОНЯ: {config.defencePerson}";
        
        config.hpPerson += armorItem.data.hp;
        config.hpPerson += otherItem.data.hp;
        hpPerson.text =$"HP: {config.hpPerson}";

        config.resitCold = armorItem.data.resistCold;
        config.resitCold = +otherItem.data.resistCold;
        resistCold.text = $"СОПРОТИВЛЕНИЕ ХОЛОДУ: {config.resitCold}";
        
        config.resitPotion = armorItem.data.resistPotion;
        config.resitPotion = +otherItem.data.resistPotion;
        resistPotion.text = $"СОПРОТИВЛЕНИЕ ЯДУ: {config.resitPotion}";
        
        config.resitFire = armorItem.data.resistFire;
        config.resitFire = +otherItem.data.resistFire;
        resistFire.text = $"СОПРОТИВЛЕНИЕ ОГНЮ: {config.resitFire}";
        
        lvlPerson.text = $"Lvl: {config.LVLPers}";

    }
}
