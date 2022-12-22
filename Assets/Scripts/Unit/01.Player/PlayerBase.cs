using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBase : UnitBase
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _deathParticlePrefab;
    [field: SerializeField] public bool IsFirstPlayer { get; set; } = true;

    private PlayerAttack attack;

    protected override void Awake()
    {
        base.Init();
        state.Stat.Spd = 5f;
        state.Stat.MaxHealth = 100;
        state.Stat.Health = 100;
        state.Stat.Atk = 10;

        AddBehaviour<PlayerInput>();
        AddBehaviour<PlayerMove>().Speed = State.Stat.Spd;
        //AddBehaviour<PlayerRotate>().RotateSpeed = 100f;
        attack = AddBehaviour<PlayerAttack>();
        attack.projectilePrefab = _bulletPrefab;
         AddBehaviour<UnitRender>().DeathParticle = _deathParticlePrefab;

        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }
}
