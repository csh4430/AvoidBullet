using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitBase : MonoBehaviour
{
    private Dictionary<Type, UnitBehaviour> behaviours;
    public T GetBehaviour<T>() where T : UnitBehaviour
    {
        return (T)behaviours[typeof(T)];
    }

    public T AddBehaviour<T>() where T : UnitBehaviour, new()
    {
        var behaviour = new T();
        behaviour.ThisUnit = this;
        behaviours.Add(typeof(T), behaviour);
        return behaviour;
    }

    private void Awake()
    {
        behaviours = new Dictionary<Type, UnitBehaviour>();
        AddBehaviour<PlayerInput>();
        AddBehaviour<PlayerMove>();

        foreach (var behaviour in behaviours.Values)
        {
            behaviour.Awake();
        }
    }

    private void Update()
    {
        foreach (var behaviour in behaviours.Values)
        {
            behaviour.Update();
        }
    }
}
