
using UnityEngine;
using UnityEngine.UI;

public class StatsEnemy : MonoBehaviour
{
   public bool isOpen;
   public string Name;
   public string Last_text;
   public EnemyEnum enemyEnum;
   public int numberEnemy;
   public int hP;
   public int damage;
   public int rewardGold;
   public int rewardBattleExp;
   public int rewardBookExp;
   public int lvlBook;
   public int rewardRubin;
   public bool rewardChes;
   public EnemyAbilityEnum enemyAbilityEnum;

   public void Init(bool isOpen)
   {
      this.isOpen = isOpen;
      GetComponent<Image>().color = isOpen ? new Color(1,1,1,1) : new Color(1,0.5f,0.5f,0.4f);
   }
  
}
