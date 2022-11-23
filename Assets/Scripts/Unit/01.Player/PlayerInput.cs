using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum InputFlags
{
    None = 0,
    LeftMove = 1 << 0,
    RightMove = 1 << 1,
    UpMove = 1 << 2,
    DownMove = 1 << 3,
    RightTurn = 1 << 4,
    LeftTurn = 1 << 5,
    Fire = 1 << 6,
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
            inputFlags |= InputFlags.UpMove;
        }
        else
        {
            inputFlags &= ~InputFlags.UpMove;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            inputFlags |= InputFlags.LeftMove;
        }
        else
        {
            inputFlags &= ~InputFlags.LeftMove;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputFlags |= InputFlags.DownMove;
        }
        else
        {
            inputFlags &= ~InputFlags.DownMove;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            inputFlags |= InputFlags.RightMove;
        }
        else
        {
            inputFlags &= ~InputFlags.RightMove;
        }
        
        if(Input.GetAxisRaw("Mouse X") > 0)
        {
            inputFlags |= InputFlags.RightTurn;
        }
        else
        {
            inputFlags &= ~InputFlags.RightTurn;
        }
        
        if(Input.GetAxisRaw("Mouse X") < 0)
        {
            inputFlags |= InputFlags.LeftTurn;
        }
        else
        {
            inputFlags &= ~InputFlags.LeftTurn;
        }
        
        if(Input.GetMouseButtonDown(0))
        {
            inputFlags |= InputFlags.Fire;
        }
        else
        {
            inputFlags &= ~InputFlags.Fire;
        }
    }
}
