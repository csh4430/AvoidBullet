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
        state.OnDeath += DeathEFF;

        AddBehaviour<UnitRender>();
        base.Awake();
    }

    private void DeathEFF()
    {
        Sound.StopEff(SoundType.EffType.Die);
        Sound.PlayEff(SoundType.EffType.Item);
    }
}
