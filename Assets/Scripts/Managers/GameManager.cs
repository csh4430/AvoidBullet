using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    private Dictionary<Type, Manager> managers;
    private static GameManager _instance = null;

    public static GameManager Instance
    {
        get
        {
            if (_instance is not null) return _instance;
            return _instance;
        }
    }
    
    public T AddManager<T>() where T : Manager, new()
    {
        var manager = new T();
        managers.Add(typeof(T), manager);
        return manager;
    }

    public T GetManager<T>() where T : Manager
    {
        if (managers.TryGetValue(typeof(T), out var manager))
        {
            return manager as T;
        }

        return null;
    }


    private void Awake()
    {
        _instance = this;
        managers = new Dictionary<Type, Manager>();
        AddManager<MapManager>();
        AddManager<PoolManager>();
        AddManager<UIManager>().StayUIMgr.FadeUI.State = FadeState.FADE_IN;
    }
    private void Start()
    {
        FlowManager.Instance.Init();
        //FlowManager.Instance.
        FlowManager.Instance.NextStep();
        Sound.PlayBgm(SoundType.BgmType.Tuto);
    }
}
