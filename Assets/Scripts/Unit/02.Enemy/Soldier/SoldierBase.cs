using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBase : EnemyBase
{
    protected override void Awake()
    {
        base.Init();
        var attack = AddBehaviour<SoldierAttack>();
        AddBehaviour<UnitRender>();

        for (var e = BulletEnum.Enemy_Player_1; e <= BulletEnum.Enemy_Bigger; e++)
        {
            attack.Bullets.Add(Bullets[(int)e]);
        }
        base.Awake();
    }

    protected override void Init()
    {
        base.Init();
    }

    protected override void OnEnable()
    {
        state.Stat.MaxHealth = 40;
        state.Stat.Health = 40;
        state.Stat.Atk = 5;
        base.OnEnable();
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
