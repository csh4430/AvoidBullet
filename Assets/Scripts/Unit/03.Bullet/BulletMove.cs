
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : UnitMove
{
    public Vector3 Dir { get; set; } = Vector3.forward;
    public GameObject Target { get; set; } = null;

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
        if (Target)
        {
            ThisUnit.transform.LookAt(Target.transform);
            Dir = Vector3.forward;
        }
        ThisUnit.transform.Translate(Dir * (Speed * Time.deltaTime), Space.Self);
    }
}
