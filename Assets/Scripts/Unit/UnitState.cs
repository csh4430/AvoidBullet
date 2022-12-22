using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

[Flags]
public enum StateEnum
{
    None = 0,
    Damage = 1 << 0,
    Heal = 1 << 1,
    Death = 1 << 2,
    Respawn = 1 << 3,
    LevelUp = 1 << 4
}

[Serializable]
public class UnitState : UnitBehaviour
{
    [field : SerializeField]
    public UnitStat Stat { get; private set; } = new UnitStat();
    [field : SerializeField]
    public StateEnum NowState { get; private set; }

    public void Damage(float value)
    {
        if (NowState.HasFlag(StateEnum.Damage)) return;
        if (NowState.HasFlag(StateEnum.Death)) return;
        Stat.Health -= value;
        SetState(StateEnum.Damage);
        
        if(Stat.Health <= 0)
        {
            Stat.Health = 0;
            RemoveState(StateEnum.Damage);
            Die();
        }
    }
    
    public virtual void Die()
    {
        if (NowState.HasFlag(StateEnum.Death)) return;
        SetState(StateEnum.Death);
    }

    public void Clear()
    {
        NowState = StateEnum.None;
        ThisUnit.GetBehaviour<UnitRender>().Clear();
    }
    public void SetState(StateEnum state)
    {
        NowState |= state;
    }
    
    public void RemoveState(StateEnum state)
    {
        NowState &= ~state;
    }
}
