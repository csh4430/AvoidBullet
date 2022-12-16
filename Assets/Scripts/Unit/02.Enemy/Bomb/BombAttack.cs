using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAttack : EnemyAttack
{
    public float Delay { get; set; } = 4f;

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
        currentTime += Time.deltaTime;
        if (currentTime >= Delay)
        {
            Attack();
            ThisUnit.State.Stat.Health = 0f;
            ThisUnit.State.SetState(StateEnum.Death);
            return;
        }
    }

    public override void Attack()
    {
        Attack(AttackType.Circle, Bullets[0], 10, 13, 1, 1f, 1);
    }
}