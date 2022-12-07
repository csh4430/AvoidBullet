using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  SoldierAttack : EnemyAttack
{
    public float Delay { get; set; } = 0.2f;

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
        currentTime += Time.deltaTime;
        if (currentTime >= Delay)
        {
            currentTime = 0f;
            Attack(AttackType.Spin, Bullets[(int)BulletEnum.Enemy_Player_1], 4, 1, 0f, 1, null, 10f);
        }
    }
}
