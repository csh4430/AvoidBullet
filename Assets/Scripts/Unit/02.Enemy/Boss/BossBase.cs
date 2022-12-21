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
        AddBehaviour<UnitRender>();
        for (var e = BulletEnum.Enemy_Player_1; e <= BulletEnum.Enemy_Bigger; e++)
        {
            attack.Bullets.Add(Bullets[(int)e]);
        }
        if (isFinalBoss)
        {
            state.Stat.MaxHealth = 2000;
            state.Stat.Health = 2000;
            state.Stat.Atk = 10;
        }
        else
        {
            state.Stat.MaxHealth = 2500;
            state.Stat.Health = 2500;
            state.Stat.Atk = 8;
        }
        base.Awake();

    }

    protected override void Init()
    {
        base.Init();
    }

    protected override void Start()
    {
        GameManager.Instance.GetManager<PoolManager>().CreatePool(bombPrefab, 5);
        GameManager.Instance.GetManager<PoolManager>().CreatePool(soldierPrefab, 5);
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }


}
