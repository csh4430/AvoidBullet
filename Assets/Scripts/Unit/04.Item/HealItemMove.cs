using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItemMove : UnitMove
{
    private Vector3 mainPos;
    public override void Awake()
    {
        base.Awake();
        mainPos = ThisUnit.transform.position;
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void Translate()
    {
        ThisUnit.transform.RotateAround(mainPos, Vector3.right, 30f);
    }
}
