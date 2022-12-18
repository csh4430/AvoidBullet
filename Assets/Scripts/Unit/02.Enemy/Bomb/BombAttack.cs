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
        ThisUnit.transform.DOLocalMoveX(0.2f,Delay).SetRelative().SetEase(Ease.Flash, 170, -1);
    }

    public override void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= Delay)
        {
            Attack();
            ThisUnit.State.Stat.Health = 0f;
            ThisUnit.State.SetState(StateEnum.Death);
            return;
        }
    }
    public override void Attack()
    {
        Attack(AttackType.Circle, Bullets[2], 10, 13, 1, 1f, 1);
    }
}