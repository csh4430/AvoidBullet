using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : UnitMove
{
    InputFlags inputFlags => ThisUnit.GetBehaviour<PlayerInput>().inputFlags;
    public int Speed { get; set; } = 1;
    public override void Awake()
    {
        base.Awake();
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void Translate()
    {
        var dir = Vector3.zero;
        if (inputFlags.HasFlag(InputFlags.Up))
        {
            dir += Vector3.forward;
        }
        if (inputFlags.HasFlag(InputFlags.Down))
        {
            dir += Vector3.back;
        }
        if (inputFlags.HasFlag(InputFlags.Left))
        {
            dir += Vector3.left;
        }
        if (inputFlags.HasFlag(InputFlags.Right))
        {
            dir += Vector3.right;
        }

        dir = dir.normalized;

        ThisUnit.transform.position += dir * (Time.deltaTime * Speed);
    }
}
