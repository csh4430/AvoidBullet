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
        AddBehaviour<PlayerInput>();
        AddBehaviour<PlayerMove>().Speed = stat.Spd;
        AddBehaviour<PlayerRotate>();
        AddBehaviour<PlayerAttack>().projectilePrefab = _bulletPrefab;
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }
}
