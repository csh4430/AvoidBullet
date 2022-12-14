using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : UnitMove
{
    public Vector3 Dir { get; set; } = Vector3.forward;

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

    }   
}