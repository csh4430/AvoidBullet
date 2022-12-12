using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//점점 조여오는 총알
public class RingBase : BulletBase
{
    protected override void Awake()
    {
        base.Awake();
        var move = AddBehaviour<RingMove>();
        move.Speed = 3;
    }
}
