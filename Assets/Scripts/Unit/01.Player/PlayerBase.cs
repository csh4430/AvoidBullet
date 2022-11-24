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
        
        AddBehaviour<PlayerInput>();
        AddBehaviour<PlayerMove>().Speed = State.Stat.Spd;
        AddBehaviour<PlayerRotate>().RotateSpeed = 100f;
        AddBehaviour<PlayerAttack>().projectilePrefab = _bulletPrefab;
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }
}
