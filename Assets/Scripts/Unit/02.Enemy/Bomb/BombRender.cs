using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRender : UnitRender
{
    public float Duration { get; set; }
    private float curRed = 0f;
    public override void Update()
    {
        base.Update();
        curRed += 1 / Duration * Time.deltaTime;
        GettingRedder();
    }

    public void GettingRedder()
    {
        Color color = new Color(125+curRed, 125 - curRed, 125 - curRed + 20);
        SetColor(color, color, 1);
    }
}
