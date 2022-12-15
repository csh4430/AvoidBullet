using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointUI : UIComponent
{
    private GameObject _pointPrefab;
    public bool _isPointActive = false;
    public UIComponent _selectedUI;

    protected override void Awake()
    {
        _pointPrefab = transform.GetChild(0).gameObject;
        _pointPrefab.SetActive(false);
        base.Awake();
    }

    protected override void Update()
    {
        _pointPrefab.SetActive(_isPointActive);
        base.Update();
    }
}
