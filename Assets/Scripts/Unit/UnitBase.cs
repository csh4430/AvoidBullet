using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnitBase : MonoBehaviour
{
    private Dictionary<Type, UnitBehaviour> behaviours;
    [SerializeField] protected UnitState state;
    public UnitState State => state;
    public T GetBehaviour<T>() where T : UnitBehaviour
    {
        return (T)behaviours[typeof(T)];
    }

    public T AddBehaviour<T>() where T : UnitBehaviour, new()
    {
        var behaviour = new T
        {
            ThisUnit = this
        };
        behaviours.Add(typeof(T), behaviour);
        return behaviour;
    }

    protected virtual void Init()
    {
        behaviours = new Dictionary<Type, UnitBehaviour>();
    }
    protected virtual void Awake()
    {
        if(behaviours.Count == 0)
        {
            return;
        }
        foreach (var behaviour in behaviours.Values)
        {
            behaviour.Awake();
        }
    }
    protected virtual void Start()
    {
        if (behaviours.Count == 0)
        {
            return;
        }
        foreach (var behaviour in behaviours.Values)
        {
            behaviour.Start();
        }
    }
    protected virtual void Update()
    {
        if(behaviours.Count == 0)
        {
            return;
        }
        foreach (var behaviour in behaviours.Values)
        {
            behaviour.Update();
        }
    }
}
