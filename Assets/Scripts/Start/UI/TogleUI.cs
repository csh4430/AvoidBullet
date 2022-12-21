using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TogleUI : UIComponent
{
   private bool isOn = true;

   public bool Value
   {
      get => isOn;
      set
      {
         isOn = value;
         _fillTranform.DOScale(isOn ? Vector3.one : Vector3.zero, 0.5f);
      }
   }
   [SerializeField]
   private Transform _fillTranform;
}
