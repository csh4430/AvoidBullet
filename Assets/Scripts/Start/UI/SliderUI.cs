using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderUI : UIComponent
{
    [Range(0.0001f, 1f)]
    [SerializeField] private float _value = 1;
    private Transform _fillTransform;

    public float Value
    {
        get => _value;
        set
        {
            _value = Mathf.Clamp(value, 0.0001f , 1);
            if (_fillTransform is null) 
                _fillTransform = transform.Find("Anchor/Fill");
            _fillTransform.localScale = new Vector3(_value, 1, 1);
        }
    }

    protected override void Awake()
    {
        base.Awake();
    }
}
