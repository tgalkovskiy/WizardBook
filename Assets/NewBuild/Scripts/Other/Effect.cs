using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Effect : MonoBehaviour
{
   [SerializeField] private Map _map;

   private void Awake()
   {
      //RenderSettings.skybox = _map.Skybox;
   }
}
