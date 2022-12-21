using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : EnemyAttack
{
    public float Delay { get; set; } = 1.5f;

    private float currentTime = 0f;

    private int phase = 1;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
        Attack();
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
            Phase(ThisUnit.State.Stat.Health, ThisUnit.State.Stat.MaxHealth);
            switch (phase)
            {
                case 1:
                    PhaseOne();
                    break;
                case 2:
                    PhaseOne();
                    PhaseTwo();
                    break;
                case 3:
                    if (ThisUnit.gameObject.GetComponent<BossBase>().isFinalBoss)
                        PhaseThree();
                    break;
            }
        }
    }
    private GameObject FindNear()
    {
        GameObject player1 = GameObject.FindGameObjectWithTag("Player_1");
        GameObject player2 = GameObject.FindGameObjectWithTag("Player_2");
        return Random.Range(1, 3) == 1 ? player1 : player2;
    }
    private IEnumerator InstantiateEnemy(GameObject prefab, int times, float delay)
    {
        for (int i = 0; i < times; i++)
        {
            float randomX = Random.Range(-19f, 20f);
            float randomZ = Random.Range(-19f, 20f);
            Object.Instantiate(prefab, new Vector3(randomX, 0, randomZ), Quaternion.identity);
            yield return new WaitForSeconds(delay);
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
        int i = Random.Range(0, 3);
        Debug.Log($"PhaseOne Pattern : {rand}");
        if (ThisUnit.gameObject.GetComponent<BossBase>().isFinalBoss)
        {
            switch (rand)
            {
                case 1:
                    Attack(AttackType.Circle, Bullets[i], 6, 10, 0.1f, 1f, Random.Range(4, 7));
                    break;
                case 2:
                    InstantiateEnemy(ThisUnit.GetComponent<BossBase>().SoldierPrefab, 5, 2);
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
                    InstantiateEnemy(ThisUnit.GetComponent<BossBase>().BombPrefab, 3, 2);
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
                    InstantiateEnemy(ThisUnit.GetComponent<BossBase>().SoldierPrefab, 2, 3);
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
                    InstantiateEnemy(ThisUnit.GetComponent<BossBase>().BombPrefab, 1, 0);
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
        Debug.Log($"PhaseTwo Pattern : {rand}");
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
                    InstantiateEnemy(ThisUnit.GetComponent<BossBase>().BombPrefab, 8, 1f);
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
        int i = Random.Range(1, 4);
        Debug.Log($"PhaseThree");
        //최종보스
        if (ThisUnit.gameObject.GetComponent<BossBase>().isFinalBoss)
        {
            Attack(AttackType.Wave, Bullets[i], 30, 10, 0.1f, 0.5f, 1);
        }
    }
}
