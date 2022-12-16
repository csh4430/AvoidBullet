using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : EnemyAttack
{
    public float Delay { get; set; } = 1f;

    private float currentTime = 0f;

    private int phase = 1;

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
    private GameObject FindNear()
    {
        return null;
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


    private void PhaseOne()
    {
        int rand = Random.Range(1, 8);
        if (!ThisUnit.gameObject.GetComponent<BossBase>().isFinalBoss)
        {
            switch (rand)
            {
                default:
                    break;
            }
        }
        else
        {
            int i = Random.Range(1, 4);
            switch (rand)
            {
                case 1:
                    Attack(AttackType.Circle, Bullets[i], 6, 10, 0.1f, 1f, Random.Range(2, 6));
                    break;
                case 2:
                    break;
                case 3:
                    Attack(AttackType.Ring, Bullets[i], 4, 5, 8, 2, 1,FindNear(), 0);

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:

                    break;
                case 7:

                    break;
                default:
                    Debug.LogError("rand is Out of range!");
                    break;
            }
        }
    }
    private void PhaseTwo()
    {
        int rand = Random.Range(1, 4);
        if (!ThisUnit.gameObject.GetComponent<BossBase>().isFinalBoss)
        {
            switch (rand)
            {
                default:
                    break;
            }
        }
        else
        {
            switch (rand)
            {
                default:
                    break;
            }
        }
    }
    private void PhaseThree()
    {
        int rand = Random.Range(1, 3);
        if (!ThisUnit.gameObject.GetComponent<BossBase>().isFinalBoss)
        {
            switch (rand)
            {
                default:
                    break;
            }
        }
        else
        {
            switch (rand)
            {
                default:
                    break;
            }
        }

    }
}
