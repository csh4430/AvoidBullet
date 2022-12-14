using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttack : EnemyAttack
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

    private int i = 0;
    public override void Attack()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= Delay)
        {
            currentTime = 0f;
            if (GameObject.Find("Player_1") == null)
                Attack(AttackType.Ring, Bullets[i], 6, 5, 8, 1f, 1, GameObject.Find("Player_2"), 10f);
            else
                Attack(AttackType.Ring, Bullets[i], 6, 5, 8, 1f, 1, GameObject.Find("Player_1"), 10f);
        }
    }
}
