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
    private int Phase(float curHealth, float maxHealth)
    {
        switch (curHealth)
        {
            case var _ when curHealth <= ThisUnit.State.Stat.MaxHealth:
                return 1;
            case var _ when curHealth <= ThisUnit.State.Stat.MaxHealth / 2:
                return 2;
            case var _ when curHealth <= ThisUnit.State.Stat.MaxHealth / 3:
                return 3;
        }
        Debug.LogError("incorrect boss hp");
        return -1;
    }

    private void ChooseRandom()
    {

    }
}
