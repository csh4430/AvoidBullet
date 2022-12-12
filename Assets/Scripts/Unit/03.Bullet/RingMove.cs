using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMove : BulletMove
{
    protected override void Translate()
    {
        if (Target)
        {
            ThisUnit.transform.LookAt(Target.transform);
            ThisUnit.transform.position = Vector3.MoveTowards(ThisUnit.transform.position, Target.transform.position, Time.deltaTime);
        }
    }
}
