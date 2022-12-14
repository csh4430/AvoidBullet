using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIFloating : UIBehaviour
{
    private Sequence seq;
    public float Amplitude = 3f;
    public float Duration = 3f;
    public override void Start()
    {
        seq = DOTween.Sequence();
        seq.Append(ThisUI.transform.DOMoveY(Amplitude, Duration / 2).SetEase(Ease.InOutSine));
        seq.Append(ThisUI.transform.DOMoveY(0, Duration / 2).SetEase(Ease.InOutSine));
        seq.SetLoops(-1);
    }
}
