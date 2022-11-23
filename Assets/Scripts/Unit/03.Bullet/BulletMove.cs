
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : UnitMove
{
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
        ThisUnit.transform.Translate(Vector3.forward * (Speed * Time.deltaTime), Space.Self);
    }
}
