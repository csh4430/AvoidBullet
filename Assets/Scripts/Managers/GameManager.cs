using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Dictionary<Type, Manager> managers;
    public T AddManager<T> () where T : Manager
    {
        T manager = Manager.Init() as T;
        managers.Add(typeof(T), manager);
        return manager;
    }
    private void Awake()
    {
        managers = new Dictionary<Type, Manager>();
        AddManager<MapManager>();   
    }
}
