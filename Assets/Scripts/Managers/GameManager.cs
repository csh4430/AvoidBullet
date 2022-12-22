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
    private Sound sound;

    public static GameManager Instance
    {
        get
        {
            if (_instance is not null) return _instance;
            _instance = GameObject.FindObjectOfType<GameManager>() ??
                        new GameObject("GameManager").AddComponent<GameManager>();
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
        managers = new Dictionary<Type, Manager>();
        AddManager<MapManager>();
        AddManager<PoolManager>();
        AddManager<UIManager>().StayUIMgr.FadeUI.State = FadeState.FADE_IN;
        sound = FindObjectOfType<Sound>();
    }

}
