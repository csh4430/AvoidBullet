using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneMgr : MonoBehaviour
{
    [SerializeField] private int _menuIdx = 0;
    
    public FadeUI _fadeUI;
    
    private List<Menu> _menus = new List<Menu>();

    private void Awake()
    {
        _menus.Add(new Menu());
        _menus.Add(new MenuPlay());
        _menus.Add(new Menu());
        _menus.Add(new Menu());

        _menus[1].StartSceneMgr = this;
    }

    private void Start()
    {
        _fadeUI.State = FadeState.FADE_IN; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _menuIdx = (_menuIdx + 1) % 4;
            RotateCamera.Rotate(_menuIdx);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            _menus[_menuIdx].Interactive();
        }
    }
}
