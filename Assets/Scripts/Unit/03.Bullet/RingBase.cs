using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� �������� �Ѿ�
public class RingBase : BulletBase
{
    protected override void Awake()
    {
        base.Awake();
        var move = AddBehaviour<RingMove>();
        move.Speed = 3;
    }
}
