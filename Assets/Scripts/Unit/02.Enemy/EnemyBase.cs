using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : UnitBase
{
    protected override void Awake()
    {
        base.Init();
        state = AddBehaviour<UnitState>();
        AddBehaviour<UnitRender>();
        state.Stat.MaxHealth = 100;
        state.Stat.Health = 100;
        base.Awake();
    }
}
