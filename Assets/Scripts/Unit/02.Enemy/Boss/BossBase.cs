using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBase : EnemyBase
{
    [SerializeField] public bool isFinalBoss { get; private set; } = false;

    protected override void Awake()
    {
        base.Awake();
        var attack = AddBehaviour<BossAttack>();
        if (isFinalBoss)
        {
            state.Stat.MaxHealth = 850;
            state.Stat.Health = 850;
            state.Stat.Atk = 10;
        }
        else
        {
            state.Stat.MaxHealth = 600;
            state.Stat.Health = 600;
            state.Stat.Atk = 8;
        }

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
