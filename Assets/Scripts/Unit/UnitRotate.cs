using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRotate : UnitBehaviour
{
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
