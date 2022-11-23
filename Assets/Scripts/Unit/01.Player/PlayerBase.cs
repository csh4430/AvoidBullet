using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBase : UnitBase
{
    protected override void Awake()
    {
        base.Init();
        AddBehaviour<PlayerInput>();
        AddBehaviour<PlayerMove>().Speed = 5f;
        AddBehaviour<PlayerRotate>();
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }
}
