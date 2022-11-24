using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : UnitBase
{
    public float LifeTime { get; set; } = 3f;
    private float _lifeTime = 3f;

    protected override void Init()
    {
        base.Init();
        _lifeTime = LifeTime;
    }

    protected override void Awake()
    {
        base.Init();
        AddBehaviour<BulletMove>().Speed = 10f;
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
        Alive();
    }
    
    private void Alive()
    {
        LifeTime -= Time.deltaTime;
        if (LifeTime <= 0)
        {
            LifeTime = _lifeTime;
            GameManager.Instance.GetManager<PoolManager>().EnqueueObject(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var theUnit = other.GetComponent<UnitBase>();
        if (theUnit != null)
        {
            theUnit.State.Stat.Health -= 10;
            LifeTime = _lifeTime;
            GameManager.Instance.GetManager<PoolManager>().EnqueueObject(gameObject);
        }
    }
}
