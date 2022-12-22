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
        ThisUnit.transform.Translate(new Vector3(0, 0, 3));
        //int rand = Random.Range(1, 3);
        //ThisUnit.gameObject.layer = rand == 1  ? LayerMask.NameToLayer("Player_1") : LayerMask.NameToLayer("Player_2");
        //Debug.Log("Current layer: " + ThisUnit.gameObject.layer + " " +rand );
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void Translate()
    {
        ThisUnit.transform.RotateAround(mainPos, Vector3.up, ThisUnit.State.Stat.Spd);
    }
}
