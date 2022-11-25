
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : UnitMove
{
    public Vector3 dir { get; set; } = Vector3.forward;
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
        ThisUnit.transform.Translate(dir.normalized * (Speed * Time.deltaTime), Space.Self);
    }
}
