using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : UnitMove
{
    InputFlags inputFlags => ThisUnit.GetBehaviour<PlayerInput>().inputFlags;
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
        if (inputFlags.HasFlag(InputFlags.UpMove))
        {
            dir += Vector3.forward;
        }
        if (inputFlags.HasFlag(InputFlags.DownMove))
        {
            dir += Vector3.back;
        }
        if (inputFlags.HasFlag(InputFlags.LeftMove))
        {
            dir += Vector3.left;
        }
        if (inputFlags.HasFlag(InputFlags.RightMove))
        {
            dir += Vector3.right;
        }

        dir = dir.normalized;

        ThisUnit.transform.Translate(dir * (Time.deltaTime * Speed), Space.Self);
    }
}
