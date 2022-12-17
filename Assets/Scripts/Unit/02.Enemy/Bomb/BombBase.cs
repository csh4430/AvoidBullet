using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBase : EnemyBase
{
    protected override void Awake()
    {
        base.Awake();
        var attack = AddBehaviour<BombAttack>();
        var render = AddBehaviour<BombRender>();
        render.Duration = attack.Delay;
        state.Stat.MaxHealth = 30;
        state.Stat.Health = 30;
        state.Stat.Atk = 7;
        for (var e = BulletEnum.Enemy_Player_1; e <= BulletEnum.Enemy_Bigger; e++)
        {
            attack.Bullets.Add(Bullets[(int)e]);
        }
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
