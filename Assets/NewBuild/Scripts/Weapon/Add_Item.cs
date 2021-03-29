using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_Item : MonoBehaviour
{
    [SerializeField] private GameObject[] Chess = default;
    [SerializeField] private GameObject Cost = default;
    [SerializeField] private GameObject NoRubin = default;
    [SerializeField] private WeaponManeger WeaponManeger = default;
    [SerializeField] private HP HP;
    private int[] Property = new int[7];
    private int Chois;
    private void Awake()
    {
       for(int i=0; i < Chess.Length; i++)
       {
            if (HP.Ches[i])
            {
                Chess[i].SetActive(true);
            } 
       } 

    }
    public void Select_Chess(int Chois)
    {
        Cost.SetActive(true);
        Chois = Chois;
    }
    public void Add()
    {
        if(HP.Rubin >= 5)
        {
            HP.Rubin -= 5;
            Property[0] = 1;
            Property[1] = Random.Range(0, 5);
            Property[2] = Grade();
            Property[3] = LVL_Item();
            if (Property[0] == 1)
            {
                Property[4] = Property_Item(Property[3], Property[2]);
            }
            else if (Property[0] == 2)
            {
                Property[4] = Property_Item(Property[3], Property[2]);
            }
            Property[6] = Cost_item(Property[3], Property[2]);
            WeaponManeger.Add_Item(Property);
            HP.Ches[Chois] = false;
            Chess[Chois].SetActive(false);
            Cost.SetActive(false);
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
    private int Grade()
    {
        int i = 0;
        int chance = Random.Range(0, 100);
        if(chance >= 90)
        {
            i = 3;
        }
        else if(chance < 90 && chance > 70)
        {
            i = 2;
        }
        else if(chance<70 && chance > 40)
        {
            i = 1;
        }
        else if(chance< 40 && chance > 0)
        {
            i = 0;
        }
        return i;
    }
    private int LVL_Item()
    {
        int Lvl = HP.LVLPers;
        int chance = Random.Range(0, 100);
        if (chance >= 90)
        {
            Lvl += 5;
        }
        else if (chance < 90 && chance > 70)
        {
            Lvl += 2;
        }
        else if (chance < 70 && chance > 40)
        {
            Lvl += 1;
        }
        else if (chance < 40 && chance > 0)
        {
            Lvl += 0;
        }
        return Lvl;
    }
    private int Property_Item(int Lvl, int Grad)
    {
        int Property = 20;
        if(Lvl == 0)
        {
            Lvl = 1;
        }
        if(Grad == 0)
        {
            Grad = 1;
        }
        int chance = Random.Range(0, 100);
        if (chance >= 90)
        {
            Property += HP.LVLPers*4 *Lvl*Grad;
        }
        else if (chance < 90 && chance > 70)
        {
            Property += HP.LVLPers*3 * Lvl * Grad;
        }
        else if (chance < 70 && chance > 40)
        {
            Property += HP.LVLPers*2 * Lvl * Grad;
        }
        else if (chance < 40 && chance > 0)
        {
            Property += HP.LVLPers*1 * Lvl * Grad;
        }
        return Property;
    }
    private int Cost_item(int Lvl_Item, int Grad)
    {
        if (Lvl_Item == 0)
        {
            Lvl_Item = 1;
        }
        if (Grad == 0)
        {
            Grad = 1;
        }
        return Lvl_Item*50*Grad;
    }

    
    
}
