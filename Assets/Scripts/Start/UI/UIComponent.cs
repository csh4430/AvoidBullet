using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIComponent : MonoBehaviour
{
    Dictionary<Type, UIBehaviour> _behaviours = new Dictionary<Type, UIBehaviour>();
    
    public T GetBehaviour<T>() where T : UIBehaviour
    {
        Type type = typeof(T);
        if (_behaviours.ContainsKey(type))
        {
            return (T)_behaviours[type];
        }

        return null;
    }
    
    public T AddBehaviour<T>() where T : UIBehaviour, new()
    {
        Type type = typeof(T);
        if (_behaviours.ContainsKey(type))
        {
            return (T)_behaviours[type];
        }
        else
        {
            T behaviour = new T();
            _behaviours.Add(type, behaviour);
            behaviour.ThisUI = this;
            return behaviour;
        }
    }
    
    protected virtual void Awake()
    {
        foreach (var behaviour in _behaviours.Values)
        {
            behaviour.Awake();
        }
    }
    
    protected virtual void Start()
    {
        foreach (var behaviour in _behaviours.Values)
        {
            behaviour.Start();
        }
    }
    
    protected virtual void Update()
    {
        foreach (var behaviour in _behaviours.Values)
        {
            behaviour.Update();
        }
    }

}
