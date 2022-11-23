using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum StateEnum
{
    None = 0,
    Damage = 1 << 0,
    Heal = 1 << 1,
    Death = 1 << 2,
    Respawn = 1 << 3,
    LevelUp = 1 << 4,
}

public class UnitState : UnitBehaviour
{
    public StateEnum NowState { get; private set; }
    
    public void SetState(StateEnum state)
    {
        NowState |= state;
    }
    
    public void RemoveState(StateEnum state)
    {
        NowState &= ~state;
    }
}
