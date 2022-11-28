using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBase : EnemyBase
{
    protected override void Awake()
    {
        base.Awake();
        AddBehaviour<SoldierAttack>().sphereBullet = sphereBullet;
    }

    protected override void Init()
    {
        base.Init();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
