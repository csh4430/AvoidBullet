using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBase : UnitBase
{
    [SerializeField] private GameObject _bulletPrefab;
    protected override void Awake()
    {
        base.Init();
        state = AddBehaviour<UnitState>();
        state.Stat.Spd = 5f;
        state.Stat.MaxHealth = 100;
        state.Stat.Health = 100;
        state.Stat.Atk = 10;

        AddBehaviour<PlayerInput>();
        AddBehaviour<PlayerMove>().Speed = State.Stat.Spd;
        //AddBehaviour<PlayerRotate>().RotateSpeed = 100f;
        AddBehaviour<PlayerAttack>().projectilePrefab = _bulletPrefab;
        AddBehaviour<UnitRender>();
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }
}
