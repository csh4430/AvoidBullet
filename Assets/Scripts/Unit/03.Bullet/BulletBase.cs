using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : UnitBase
{
    protected override void Awake()
    {
        base.Init();
        AddBehaviour<BulletMove>().Speed = 10f;
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }
}
