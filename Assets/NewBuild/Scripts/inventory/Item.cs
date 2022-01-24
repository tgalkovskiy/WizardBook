
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public class ItemData
{
    public bool isItem;
    public ItemType itemType;
    public Grade grade;
    public int iconItem;
    public int lvlItem;
    public int maxLvlItem;
    public int damage;
    public int defence;
    public int hp;
    public int resistFire;
    public int resistCold;
    public int resistPotion;
    public int costUp;
    public int costTrade;
}
public class Item : MonoBehaviour, IPointerDownHandler
{
    public ItemData data;
    [Tooltip("0 - Type_Item" + "\n" +
        "1 - Icon_Item" + "\n" +
        "2 - Icon_Crad" + "\n" +
        "3 - Lvl_Item" + "\n" +
        "4 - Damage" + "\n" +
        "5 - Defence" + "\n" +
        "6 - Start_Cost" + "\n" +
        "7 - maxLVL" + "\n" +
        "8 - HP")] public int[] Property_Item;
    
    public Image iconItem;
    public Image gradeItemIcon;
    public Sprite defaultSpriteGrade;
    public Sprite defaultSpriteIcon;
    public Sprite[] weaponSprite;
    public Sprite[] armorSprite;
    public Sprite[] otherSprite;
    public Sprite[] gradeSprite;
    
    private void Start()
    {
        VisualiseItem();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        WeaponManager.selectItem = this;
    }

    public void VisualiseItem()
    {
        if(data.isItem)
        {
            iconItem.sprite = data.itemType switch
            {
                ItemType.Weapon => weaponSprite[data.iconItem],
                ItemType.Armor => armorSprite[data.iconItem],
                ItemType.Other => otherSprite[data.iconItem],
                _ => iconItem.sprite
            };
            gradeItemIcon.sprite = gradeSprite[(int)data.grade];
        }
        else
        {
            gradeItemIcon.sprite = defaultSpriteGrade;
            iconItem.sprite = defaultSpriteIcon;
        }
    }
}
