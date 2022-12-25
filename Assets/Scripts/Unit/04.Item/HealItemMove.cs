using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HealItemMove : UnitMove
{
    public override void Awake()
    {
        base.Awake();
        ThisUnit.transform.DOMoveX(2f, 1f).SetEase(Ease.InSine).SetLoops(-1,LoopType.Yoyo);
        //ThisUnit.transform.Translate(new Vector3(0, 0, 3));
        //int rand = Random.Range(1, 3);
        //ThisUnit.gameObject.layer = rand == 1  ? LayerMask.NameToLayer("Player_1") : LayerMask.NameToLayer("Player_2");
        //Debug.Log("Current layer: " + ThisUnit.gameObject.layer + " " +rand );
    }

    public override void Update()
    {
        base.Update();
    }
}
