using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRotate : UnitBehaviour
{
    public float RotateSpeed { get; set; } = 45;
    public override void Awake()
    {
        base.Awake();
    }

    public override void Update()
    {
        base.Update();
        Rotate();
    }

    protected virtual void Rotate(){}
}
