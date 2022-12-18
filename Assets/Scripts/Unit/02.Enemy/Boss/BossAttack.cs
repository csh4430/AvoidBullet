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
    private void InstantiateEnemy(GameObject prefab, int times)
    {
        for (int i = 0; i < times; i++)
        {
            float randomX = Random.Range(-19f, 20f);
            float randomZ = Random.Range(-19f, 20f);
            Object.Instantiate(ThisUnit.gameObject.GetComponent<BossBase>().SoldierPrefab, new Vector3(randomX, 0, randomZ), Quaternion.identity);
        }
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
        int i = Random.Range(1, 4);
        if (ThisUnit.gameObject.GetComponent<BossBase>().isFinalBoss)
        {
            switch (rand)
            {
                case 1:
                    Attack(AttackType.Circle, Bullets[i], 6, 10, 0.1f, 1f, Random.Range(4, 7));
                    break;
                case 2:
                    InstantiateEnemy(ThisUnit.GetComponent<BossBase>().SoldierPrefab, 5);
                    break;
                case 3:
                    Attack(AttackType.Sector, Bullets[i], 6, 10, 0.1f, 2, 3, FindNear(), 50);
                    break;
                case 4:
                    Attack(AttackType.Ring, Bullets[i], 6, 5, 8, 3, 3, FindNear());
                    break;
                case 5:
                    Attack(AttackType.Sector, Bullets[i], 12, 5, 8, 2, 10, ThisUnit.gameObject, 75);
                    break;
                case 6:
                    InstantiateEnemy(ThisUnit.GetComponent<BossBase>().BombPrefab, 3);
                    break;
                case 7:
                    Attack(AttackType.Spin, Bullets[i], 15, 10, 0.1f, 2, 6);
                    break;
                default:
                    break;
            }
        }
        else //중간보스
        {
            switch (rand)
            {
                case 1:
                    Attack(AttackType.Circle, Bullets[i], 6, 10, 0.1f, 1f, Random.Range(2, 6));
                    break;
                case 2:
                    InstantiateEnemy(ThisUnit.GetComponent<BossBase>().SoldierPrefab, 2);
                    break;
                case 3:
                    Attack(AttackType.Sector, Bullets[i], 3, 10, 0.1f, 2, 3, FindNear(), 45);
                    break;
                case 4:
                    Attack(AttackType.Ring, Bullets[i], 4, 5, 8, 3, 3, FindNear());
                    break;
                case 5:
                    Attack(AttackType.Sector, Bullets[i], 6, 5, 8, 2, 6, ThisUnit.gameObject, 60);
                    break;
                case 6:
                    InstantiateEnemy(ThisUnit.GetComponent<BossBase>().BombPrefab, 1);
                    break;
                case 7:
                    Attack(AttackType.Spin, Bullets[i], 10, 10, 0.1f, 2, 3);
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
        int i = Random.Range(1, 4);
        if (ThisUnit.gameObject.GetComponent<BossBase>().isFinalBoss)
        {
            switch (rand)
            {
                case 1:
                    Attack(AttackType.Target, Bullets[i], 3, 10, 0.1f, 2, Random.Range(1, 4), FindNear());
                    break;
                case 2:
                    Attack(AttackType.Target, Bullets[i], 5, 5, 0.1f, 2, 1, FindNear());
                    break;
                case 3:
                    InstantiateEnemy(ThisUnit.GetComponent<BossBase>().BombPrefab, 8);
                    break;
                default:
                    break;
            }
        }
        else //중간보스
        {
            switch (rand)
            {
                case 1:
                    Attack(AttackType.Target, Bullets[i], 4, 10, 0.1f, 2f, 1, FindNear());
                    break;
                case 2:
                    Attack(AttackType.Spin, Bullets[i], 10, 10, 0.1f, 2f, Random.Range(2, 4));
                    break;
                case 3:
                    Attack(AttackType.Circle, Bullets[i], 12, 10, 0.1f, 2f, Random.Range(2, 4));
                    break;
                default:
                    break;
            }
        }
    }
    private void PhaseThree()
    {
        if (ThisUnit.gameObject.GetComponent<BossBase>().isFinalBoss)
        {

        }
    }
}
