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

    private void OnCollisionEnter(Collision collision)
    {
        var theUnit = collision.gameObject.GetComponent<UnitBase>();
        if (theUnit is null) return;
        theUnit.Stat.Health -= 10;
        GameManager.Instance.GetManager<PoolManager>().EnqueueObject(gameObject);
    }
}
