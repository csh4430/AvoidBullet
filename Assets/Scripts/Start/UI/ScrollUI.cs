using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ScrollUI : UIComponent
{
    public Transform content;
    public Transform contentClone;

    private Vector3 originalPos;

    protected override void Start()
    {
        originalPos = contentClone.localPosition;
        base.Start();
    }

    protected override void Update()
    {
        content.localPosition -= Vector3.up * Time.deltaTime * 10;
        contentClone.localPosition -= Vector3.up * Time.deltaTime * 10;
        if (content.localPosition.y < -100)
            content.localPosition = originalPos;
        if(contentClone.localPosition.y < -100)
            contentClone.localPosition = originalPos;
        base.Update();
    }
}
