using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
   public Text _Text;
   private Presenter _presenter;
   private float X;

   
   private void Awake()
   {
      _presenter = GetComponent<Presenter>();
   }
   
   public void GetCount(int a)
   {
      Debug.Log(1);
      _presenter.ChengeCountPresenter(a);
   }

   public void MoveGameObj(GameObject gameObject)
   {
      gameObject.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 1).OnComplete((() => GetCount(5)));
   }

   public void SetCount(int a)
   {
      Debug.Log(4);
      _Text.text = a.ToString();
   }

   private void OnGUI()
   {
      if (Event.current.Equals(Event.KeyboardEvent(KeyCode.A.ToString())))
      {
         //GetCount(15);
         MoveGameObj(_Text.gameObject);
      }
   }
   /*private void Update()
   {
      X = Input.GetAxis("Horizontal");
      if(X>0.5f)
      {
         GetCount(15);
      }
   }
   */
   
   
   
}
