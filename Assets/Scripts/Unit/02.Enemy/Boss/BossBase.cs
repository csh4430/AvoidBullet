using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBase : EnemyBase
{
    [field: SerializeField]  public bool isFinalBoss { get; set; } = false;
    [SerializeField] private GameObject player1 { get; }
    [SerializeField] private GameObject player2 { get; }

    [SerializeField] private GameObject soldierPrefab;
    [SerializeField] private GameObject bombPrefab;

    public GameObject BombPrefab => bombPrefab;
    public GameObject SoldierPrefab => soldierPrefab;
    protected override void Awake()
    {
        base.Init();
        var attack = AddBehaviour<BossAttack>();
        for (var e = BulletEnum.Enemy_Player_1; e <= BulletEnum.Enemy_Bigger; e++)
        {
            attack.Bullets.Add(Bullets[(int)e]);
        }
        base.Awake();
        if (isFinalBoss)
        {
            state.Stat.MaxHealth = 1700;
            state.Stat.Health = 1700;
            state.Stat.Atk = 10;
        }
        else
        {
            state.Stat.MaxHealth = 1300;
            state.Stat.Health = 1300;
            state.Stat.Atk = 8;
        }

    }

    protected override void Init()
    {
        base.Init();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }


}
