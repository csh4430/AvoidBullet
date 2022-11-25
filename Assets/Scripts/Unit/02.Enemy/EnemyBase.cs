using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : UnitBase
{
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private GameObject sphereBullet;

    protected override void Awake()
    {
        base.Init();
        state = AddBehaviour<UnitState>();
        AddBehaviour<UnitRender>().DeathParticle = deathEffect;
        AddBehaviour<EnemyAttack>().sphereBullet = sphereBullet;
        state.Stat.MaxHealth = 100;
        state.Stat.Health = 100;
        base.Awake();
    }
}
