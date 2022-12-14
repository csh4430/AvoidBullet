using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FloatUI : UIComponent
{
    UIFloating _uiFloating;
    protected override void Awake()
    {
        _uiFloating = AddBehaviour<UIFloating>(); 
        _uiFloating.Amplitude = 0.1f;
        _uiFloating.Duration = 3f;
        base.Awake();
    }
}
