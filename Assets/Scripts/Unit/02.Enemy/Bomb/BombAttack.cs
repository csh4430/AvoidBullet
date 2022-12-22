using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BombAttack : EnemyAttack
{
    public float Delay { get; set; } = 5f;

    private float currentTime = 0f;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        ThisUnit.State.Clear();
        ThisUnit.transform.DOLocalMoveX(0.2f,Delay).SetRelative().SetEase(Ease.Flash, 170, -1);
    }

    public override void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= Delay)
        {
            Attack();
            currentTime = 0;
            ThisUnit.State.Die();
            return;
        }
    }
    public override void Attack()
    {
        Attack(AttackType.Circle, Bullets[2], 10, 13, 1, 1f, 1);
    }
}