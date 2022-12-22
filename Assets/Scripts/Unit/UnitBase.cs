using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UnitBase : MonoBehaviour
{
    private Dictionary<Type, UnitBehaviour> behaviours;
    [SerializeField] protected UnitState state; 
    public UnitState State => state;
    public T GetBehaviour<T>() where T : UnitBehaviour
    {
        if (typeof(T).BaseType == typeof(UnitBehaviour))
        {
            return (T)behaviours[typeof(T)];
        }
        return (T)behaviours[typeof(T).BaseType];
    }

    public T AddBehaviour<T>() where T : UnitBehaviour, new()
    {
        var behaviour = new T
        {
            ThisUnit = this
        };
        behaviours.Add(typeof(T).BaseType == typeof(UnitBehaviour) ? typeof(T) : typeof(T).BaseType, behaviour);
        return behaviour;
    }

    protected virtual void Init()
    {
        behaviours = new Dictionary<Type, UnitBehaviour>();
        state = AddBehaviour<UnitState>();
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

    protected virtual void OnEnable()
    {
        if(behaviours.Count == 0)
        {
            return;
        }
        foreach (var behaviour in behaviours.Values)
        {
            behaviour.OnEnable();
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
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (behaviours.Count == 0)
        {
            return;
        }
        foreach (var behaviour in behaviours.Values)
        {
            behaviour.OnTriggerEnter(other);
        }
    }
    public static bool operator==(UnitBase thisUnit, BulletTarget target)
    {
        return target.HasFlag(Enum.Parse<BulletTarget>(thisUnit.tag));
    }
    
    public static bool operator!=(UnitBase thisUnit, BulletTarget target)
    {
        return !(thisUnit == target);
    }
}
