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
        if (inputFlags.HasFlag(InputFlags.Up))
        {
            ThisUnit.transform.position += Vector3.forward * Time.deltaTime;
        }
    }
}
