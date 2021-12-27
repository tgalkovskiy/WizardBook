using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presenter : MonoBehaviour
{
   private View _view;
   private Model _model;
   
   private void Awake()
   {
      _model = new Model();
      _view = GetComponent<View>();
   }

   private void Start()
   {
      _model.changeIntAction += _view.SetCount;
   }

   public void ChengeCountPresenter(int a)
   {
      Debug.Log(2);
      _model.RefreshCount(a);
   }
}
