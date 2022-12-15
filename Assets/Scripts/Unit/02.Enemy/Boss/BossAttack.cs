using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : EnemyAttack
{
    public float Delay { get; set; } = 1f;

    private float currentTime = 0f;


    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        Attack();
    }

    public override void Attack()
    {

    }

    private int Phase()
    {
        int p = ThisUnit.GetComponent<BossBase>().isFinalBoss ? 2 : 3;
        for (int i = 1; i < p; i++)
        {
            if (ThisUnit.State.Stat.MaxHealth / p * i == )
                return i;
        }
        return -1;
    }
}
