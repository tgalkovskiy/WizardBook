
using System;
using UnityEngine;
using UnityEngine.UI;

public class StatEnemy : MonoBehaviour
{
   public bool isOpen;
   public string Name;
   public string Last_text;
   public int NumberEnemy;
   public int HP;
   public int Damage;
   public int Gold;
   public int Exp;
   public int ExpBook;
   public int lvlBook;
   public int Rubin;
   public bool Chess;

   public void Init(bool isOpen)
   {
      this.isOpen = isOpen;
      GetComponent<Image>().color = isOpen ? new Color(1,1,1,1) : new Color(1,0.5f,0.5f,0.4f);
   }
  
}
