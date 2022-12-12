using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  SoldierAttack : EnemyAttack
{
    public float Delay { get; set; } = 3f;

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

    private int i = 0;
    public override void Attack()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= Delay)
        {
            currentTime = 0f;
            Attack(AttackType.Ring, Bullets[3], 8, 3, 5f, 1, GameObject.Find("Player_1"), 10f);
            i = (i + 1) % 2;
        }
    }
}
