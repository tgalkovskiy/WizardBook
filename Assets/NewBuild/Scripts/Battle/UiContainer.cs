
using System;
using UnityEngine;
using UnityEngine.UI;

public class UiContainer : MonoBehaviour
{
   public Slider sliderHpPlayer;
   public Text hpPlayerText;
   public Slider hpSliderEnemy;
   public Text hpTextEnemy;
   public Text timer;
   public Text mainWord;
   public Button buttonArson;
   public Button buttonShield;
   public Button buttonDeleteWrongWord;
   public Button buttonTimeStop;
   private Image _imageButtonArson;
   private Image _imageButtonShield;
   private Image _imageButtonDeleteWrongWord;
   private Image _imageButtonTimeStop;
   public Sprite wrong;
   public Sprite correct;
   public Sprite original;

   private void Awake()
   {
       _imageButtonArson = buttonArson.transform.GetComponent<Image>();
       _imageButtonShield = buttonShield.transform.GetComponent<Image>();
       _imageButtonDeleteWrongWord = buttonDeleteWrongWord.transform.GetComponent<Image>();
       _imageButtonTimeStop = buttonTimeStop.transform.GetComponent<Image>();
   }

   public void InitSkillsButton(SkillController skillController, GameConfig config)
   {
       if(config.Skills[1])
       {
           buttonArson.gameObject.SetActive(true);
           buttonArson.onClick.AddListener(()=>
           {
               skillController.ActiveArson();
               _imageButtonArson.fillAmount = 0;
           });
       }
       if(config.Skills[3])
       {
           buttonDeleteWrongWord.gameObject.SetActive(true);
           buttonDeleteWrongWord.onClick.AddListener(()=>
           {
               skillController.ActiveDeleteWrongWord();
               _imageButtonDeleteWrongWord.fillAmount = 0;
           });
       }
       if(config.Skills[7])
       {
           buttonShield.gameObject.SetActive(true);
           buttonShield.onClick.AddListener(()=>
           {
               skillController.ActiveShield();
               _imageButtonShield.fillAmount = 0;
           });
       }
       if(config.Skills[9])
       {
           buttonTimeStop.gameObject.SetActive(true);
           buttonTimeStop.onClick.AddListener(()=>
           {
               skillController.ActiveTimeStop();
               _imageButtonTimeStop.fillAmount = 0;
           });
       }
   }
   public void UpdateButtonSkills()
   {
       _imageButtonArson.fillAmount += 0.166f;
       _imageButtonShield.fillAmount += 1 / (0.01f + SkillController.Cooldown_Deff);
       _imageButtonTimeStop.fillAmount +=1/(0.01f+SkillController.CoolDown_Time);
       _imageButtonDeleteWrongWord.fillAmount +=1/(0.01f+SkillController.Cooldown_Watter);
   }
   
}
