using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIFading : UIBehaviour
{
    private Image thisImage;
    public float Duration = 1f;

    public override void Awake()
    {
        thisImage = ThisUI.GetComponent<Image>();
    }

    public void FadeIn()
    {
        thisImage.DOFade(0, Duration);
    }
    
    public void FadeOut()
    {
        thisImage.DOFade(1, Duration);
    }
}
