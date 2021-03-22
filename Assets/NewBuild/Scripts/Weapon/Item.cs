using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerDownHandler
{
    [Tooltip("0 - Type_Item" + "\n" +
        "1 - Icon_Item" + "\n" +
        "2 - Icon_Crad" + "\n" +
        "3 - Lvl_Item" + "\n" +
        "4 - Damage" + "\n" +
        "5 - Defence" + "\n" +
        "6 - Start_Cost")] public int[] Property_Item;
    [SerializeField] private Image Icon_Item;
    [SerializeField] private Image Crad_Item;

    [SerializeField] private Sprite[] Sprite_Weapon;
    [SerializeField] private Sprite[] Sprite_Armor;
    [SerializeField] private Sprite[] Sprite_Other;
    [SerializeField] private Sprite[] Grad_Sprite;

    private void Start()
    {
        Visulity_Item();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        WeaponManeger.Now_Item = this.gameObject.GetComponent<Item>();
    }

    public void Visulity_Item()
    {
        if(Property_Item[0] != 0)
        {
            Crad_Item.sprite = Grad_Sprite[Property_Item[2]];
            Icon_Item.sprite = Sprite_Weapon[Property_Item[1]];
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
