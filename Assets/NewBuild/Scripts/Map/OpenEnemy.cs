
using System;
using UnityEngine;


public class OpenEnemy : MonoBehaviour
{
   public Map map;
   public StatEnemy[] statEnemy;

   private void Awake()
   {
      map.LoadData();
      for(int i = 0; i < statEnemy.Length; i++)
      {
         statEnemy[i].Init(map.enemyNumber[i]);
      }
   }
}
