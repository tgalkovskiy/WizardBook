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
    private int[] Property = new int[9];
    private int Chois_War;
    public int Property_War;
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
        Chois_War = Chois;
    }
    public void Add()
    {
        if(HP.Rubin >= 5)
        {
            HP.Rubin -= 5;
            Property[0] = Type_item();
            Property[1] = Random.Range(0, 5);
            Property[2] = Grade();
            Property[3] = LVL_Item();
            CoolBack(Property[0]);
            Property[6] = Cost_item(Property[3], Property[2]);
            Property[7] = Max_Lvl_Item(Property[3], Property[2]);
            WeaponManeger.Add_Item(Property);
            HP.Ches[Chois_War] = false;
            Chess[Chois_War].SetActive(false);
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
    private void CoolBack(int Type)
    {
        if (Type == 1)
        {
            Property[4] = Property_Item_W(Property[3], Property[2]);
            int Chanse = Random.Range(0, 100);
            if (Chanse > 60)
            {
                Property[8] = Property_Item_O(Property[3], Property[2]) / 3;
            }
            Property[5] = 0;
        }
        else if (Type == 2)
        {
            Property[5] = Property_Item_A(Property[3], Property[2]);
            int Chanse = Random.Range(0, 100);
            if (Chanse > 50)
            {
                Property[8] = Property_Item_O(Property[3], Property[2]) / 2;
            }
            Property[4] = 0;
        }
        else if(Type == 3)
        {
            int ChanseW = Random.Range(0, 100);
            int ChanseA = Random.Range(0, 100);
            Property[8] = Property_Item_O(Property[3], Property[2]);
            if (ChanseW > 95)
            {
                Property[4] = Property_Item_W(Property[3], Property[2]) / 5;
            }
            if (ChanseA > 90)
            {
                Property[5] = Property_Item_A(Property[3], Property[2]) / 5;
            }
        }
    }
    private int Type_item()
    {
        int i = 0;
        i = Random.Range(0, 100);
        if (i < 50)
        {
            i = 1;
        }
        else if(i>50 && i < 80)
        {
            i = 2;
        }
        else
        {
            i = 3;
        }
        return i;
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
    private int Property_Item_W(int Lvl, int Grad)
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
            Property += 7 *Lvl*Grad;
        }
        else if (chance < 90 && chance > 70)
        {
            Property += 5 * Lvl * Grad;
        }
        else if (chance < 70 && chance > 40)
        {
            Property += 3 * Lvl * Grad;
        }
        else if (chance < 40 && chance > 0)
        {
            Property += 1 * Lvl * Grad;
        }
        return Property;
    }
    private int Property_Item_A(int Lvl, int Grad)
    {
        int Property = 0;
        if (Lvl == 0)
        {
            Lvl = 1;
        }
        if (Grad == 0)
        {
            Grad = 1;
        }
        int chance = Random.Range(0, 100);
        if (chance >= 90)
        {
            Property +=  4 * Lvl * Grad;
        }
        else if (chance < 90 && chance > 70)
        {
            Property +=  3 * Lvl * Grad;
        }
        else if (chance < 70 && chance > 40)
        {
            Property +=   2 * Lvl * Grad;
        }
        else if (chance < 40 && chance > 0)
        {
            Property +=   1 * Lvl * Grad;
        }
        return Property;
    }
    private int Property_Item_O(int Lvl, int Grad)
    {
        int Property = 0;
        if (Lvl == 0)
        {
            Lvl = 1;
        }
        if (Grad == 0)
        {
            Grad = 1;
        }
        int chance = Random.Range(0, 100);
        if (chance >= 90)
        {
            Property += 4 * Lvl * Grad;
        }
        else if (chance < 90 && chance > 70)
        {
            Property += 3 * Lvl * Grad;
        }
        else if (chance < 70 && chance > 40)
        {
            Property += 2 * Lvl * Grad;
        }
        else if (chance < 40 && chance > 0)
        {
            Property += 1 * Lvl * Grad;
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
    private int Max_Lvl_Item(int Lvl_Item, int Grad)
    {
        int Max_lvl = 0;
        if(Grad == 0)
        {
            Max_lvl = Lvl_Item + 5;
        }
        else if(Grad == 1)
        {
            Max_lvl = Lvl_Item + 7;
        }
        else if (Grad == 2)
        {
            Max_lvl = Lvl_Item + 9;
        }
        else if (Grad == 3)
        {
            Max_lvl = Lvl_Item + 11;
        }
        return Max_lvl;
    }
    


    
    
}
