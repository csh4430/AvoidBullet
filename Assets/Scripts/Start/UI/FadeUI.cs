using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum FadeState
{
    NONE = 0,
    FADE_IN = 1 << 0,
    FADE_OUT = 1 << 1,
}

public class FadeUI : UIComponent
{
    [SerializeField]
    private FadeState state;
    public  FadeState State
    {
        get => state; 
        set => state = value;
    }
    
    private UIFading fading;

    protected override void Awake()
    {
        fading = AddBehaviour<UIFading>();
        fading.Duration = 2f;
        base.Awake();
    }

    protected override void Update()
    {
        SetFade();
        base.Update();
    }

    public void SetFade()
    {
        switch(state)
        {
            case FadeState.FADE_IN:
                fading.FadeIn();
                state = FadeState.NONE;
                break;
            case FadeState.FADE_OUT:
                fading.FadeOut();
                break;
        }
        state = FadeState.NONE;
    }
}
