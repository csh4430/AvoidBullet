using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : EnemyAttack
{
    public float Delay { get; set; } = 1.5f;

    private float currentTime = 1.5f;

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
        currentTime += Time.deltaTime;
        if (currentTime >= Delay)
        {
            currentTime = 0f;
            phase = Phase(ThisUnit.State.Stat.Health, ThisUnit.State.Stat.MaxHealth);
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
    private GameObject FindRandom()
    {
        GameObject player1 = GameObject.FindGameObjectWithTag("Player_1");
        GameObject player2 = GameObject.FindGameObjectWithTag("Player_2");
        return Random.Range(1, 3) == 1 ? player1 : player2;
    }
 
    private int Phase(float curHealth, float maxHealth)
    {
        int nextPhase = 0;
        switch (curHealth)
        {
            case var _ when curHealth <= ThisUnit.State.Stat.MaxHealth / 3:
                nextPhase = 3;
                break;
            case var _ when curHealth <= ThisUnit.State.Stat.MaxHealth / 2:
                nextPhase = 2;
                break;
            case var _ when curHealth <= ThisUnit.State.Stat.MaxHealth:
                nextPhase = 1; 
                break;
        }
        //if (phase != nextPhase)
        //    Debug.Log("Phase has changed. Now Phase : " + nextPhase);
        //else
        //    Debug.Log(phase);
        return nextPhase;
    }


    private void PhaseOne()
    {
        int rand = Random.Range(1, 8);
        int i = Random.Range(0, 3);
        //Debug.Log($"PhaseOne Pattern : {rand}");
        if (ThisUnit.gameObject.GetComponent<BossBase>().isFinalBoss)
        {
            switch (rand)
            {
                case 1:
                    Attack(AttackType.Circle, Bullets[i], 6, 10, 0.1f, 1f, Random.Range(4, 7));
                    break;
                case 2:
                    Attack(AttackType.Instantiate, ThisUnit.GetComponent<BossBase>().SoldierPrefab,1,10,0.1f,2f,1);
                    break;
                case 3:
                    Attack(AttackType.Sector, Bullets[2], 6, 10, 0.1f, 2, 3, FindRandom(), 50);
                    break;
                case 4:
                    Attack(AttackType.Ring, Bullets[2], 6, 5, 8, 3, 3, FindRandom());
                    break;
                case 5:
                    Attack(AttackType.Sector, Bullets[2], 12, 5, 8, 2, 10, ThisUnit.gameObject, 75);
                    break;
                case 6:
                    Attack(AttackType.Instantiate, ThisUnit.GetComponent<BossBase>().BombPrefab,1,10,0.1f,2f,2);
                    //InstantiateEnemy(ThisUnit.GetComponent<BossBase>().BombPrefab, 3, 2);
                    break;
                case 7:
                    Attack(AttackType.Spin, Bullets[i], 15, 10, 0.1f, 1, 6);
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
                    //InstantiateEnemy(ThisUnit.GetComponent<BossBase>().SoldierPrefab, 2, 3);
                    Attack(AttackType.Instantiate, ThisUnit.GetComponent<BossBase>().BombPrefab,1,10,0.1f,2f,1);
                    break;
                case 3:
                    Attack(AttackType.Sector, Bullets[2], 3, 10, 0.1f, 2, 3, FindRandom(), 45);
                    break;
                case 4:
                    Attack(AttackType.Ring, Bullets[2], 4, 5, 8, 3, 3, FindRandom());
                    break;
                case 5:
                    Attack(AttackType.Sector, Bullets[2], 6, 5, 8, 2, 6, ThisUnit.gameObject, 60);
                    break;
                case 6:
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
        //Debug.Log($"PhaseTwo Pattern : {rand}");
        if (ThisUnit.gameObject.GetComponent<BossBase>().isFinalBoss)
        {
            switch (rand)
            {
                case 1:
                    Attack(AttackType.Target, Bullets[2], 3, 10, 0.1f, 2, Random.Range(1, 4), FindRandom());
                    break;
                case 2:
                    Attack(AttackType.Target, Bullets[2], 5, 5, 0.1f, 2, 1, FindRandom());
                    break;
                case 3:
                    Attack(AttackType.Ring, Bullets[i], 6, 3, 8, 3, 1, FindRandom());
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
                    Attack(AttackType.Target, Bullets[2], 4, 10, 0.1f, 2f, 1, FindRandom());
                    break;
                case 2:
                    Attack(AttackType.Spin, Bullets[i], 10, 10, 0.1f, 1f, Random.Range(1, 3));
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
        //최종보스
        if (ThisUnit.gameObject.GetComponent<BossBase>().isFinalBoss)
        {
            Attack(AttackType.Spin, Bullets[i], 30, 10, 0.1f, 0.5f, 1);
        }
    }
}
