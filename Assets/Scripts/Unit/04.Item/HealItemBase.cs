using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItemBase : UnitBase
{
    public HealItemMove move { get; private set; }
    protected override void Awake()
    {
        base.Init();
        move = AddBehaviour<HealItemMove>();
        state.Stat.MaxHealth = 1000;
        state.Stat.Health = 1000;
        state.Stat.Spd = 2f;
        AddBehaviour<UnitRender>();
        base.Awake();
    }
}
