using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : UnitRotate
{   
    InputFlags inputFlags => ThisUnit.GetBehaviour<PlayerInput>().inputFlags;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void Rotate()
    {
        if(inputFlags.HasFlag(InputFlags.RightTurn))
        {
            ThisUnit.transform.Rotate(0, RotateSpeed * Time.deltaTime, 0);
        }
        
        if(inputFlags.HasFlag(InputFlags.LeftTurn))
        {
            ThisUnit.transform.Rotate(0, -RotateSpeed * Time.deltaTime, 0);
        }
    }
}
