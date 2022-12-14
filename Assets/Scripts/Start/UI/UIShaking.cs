using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIShaking : UIBehaviour
{
    public override void Start()
    {
        ThisUI.transform.DOShakePosition(0.1f, 2).SetLoops(-1);
    }
}
