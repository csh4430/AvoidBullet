using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum InputFlags
{
    None = 0,
    Left = 1 << 0,
    Right = 1 << 1,
    Up = 1 << 2,
    Down = 1 << 3,
    Jump = 1 << 4,
    Attack = 1 << 5,
    Pause = 1 << 6,
    Quit,
}

public class PlayerInput : UnitBehaviour
{
    public InputFlags inputFlags = InputFlags.None;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            inputFlags |= InputFlags.Up;
        }
        else
        {
            inputFlags &= ~InputFlags.Up;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            inputFlags |= InputFlags.Left;
        }
        else
        {
            inputFlags &= ~InputFlags.Left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputFlags |= InputFlags.Down;
        }
        else
        {
            inputFlags &= ~InputFlags.Down;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            inputFlags |= InputFlags.Right;
        }
        else
        {
            inputFlags &= ~InputFlags.Right;
        }
    }
}
