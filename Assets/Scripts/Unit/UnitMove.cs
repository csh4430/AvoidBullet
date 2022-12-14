using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : UnitBehaviour
{
    public Vector3 Dir { get; set; } = Vector3.zero;
    public float Speed { get; set; } = 1;
    public override void Awake()
    {
        base.Awake();
    }

    public override void Update()
    {
        Translate();
    }
    
    protected virtual void Translate()
    {
        if(Dir !=Vector3.zero)
        ThisUnit.transform.Translate(Dir * (Time.deltaTime * Speed), Space.Self);
    }
}
