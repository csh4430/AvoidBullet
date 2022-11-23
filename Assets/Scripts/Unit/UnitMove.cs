using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : UnitBehaviour
{
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
        
    }
}
