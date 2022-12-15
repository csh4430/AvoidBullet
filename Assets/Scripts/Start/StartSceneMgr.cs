using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartSceneMgr : MonoBehaviour
{
    [SerializeField] private int _menuIdx = 0;
    
    public FadeUI _fadeUI;
    [SerializeField] private List<PointUI> _points = new List<PointUI>();
    
    private List<Menu> _menus = new List<Menu>();

    private void Awake()
    {
        _menus.Add(new Menu());
        _menus.Add(new MenuPlay());
        _menus.Add(new MenuSetting());
        _menus.Add(new Menu());

        _menus[1].StartSceneMgr = this;
        _menus[2].StartSceneMgr = this;
        
        ((MenuSetting)_menus[2]).points = _points;

        foreach (var menu in _menus)
        {
            menu.Awake();
        }
    }

    private void Start()
    {
        _fadeUI.State = FadeState.FADE_IN;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_menus[_menuIdx].IsOpen)
            {
                return;
            }
            _menuIdx = (_menuIdx + 1) % 4;
            RotateCamera.Rotate(_menuIdx);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            _menus[_menuIdx].Interactive();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _menus[_menuIdx].Deinteractive();
        }
        
        _menus[_menuIdx].Update();
    }
}
