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
    [SerializeField] private GameObject _pauseObject;
    [SerializeField] private GameObject _rewindObject;
    //[SerializeField] private GameObject _moveTutoObject;

    private int sceneIdx = 0;
    
    private UIFading fading;

    protected override void Awake()
    {
        fading = AddBehaviour<UIFading>();
        fading.Duration = 1.5f;
        fading.disableOnFadeIn.Add(_pauseObject);
        fading.disableOnFadeIn.Add(_rewindObject);
        //fading.disableOnFadeIn.Add(_moveTutoObject);
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
                fading.FadeOut(sceneIdx);
                break;
        }
        state = FadeState.NONE;
    }
    
    public void SetIndex(int idx)
    {
        sceneIdx = idx;
    }
    
    public void SubIndex(int value)
    {
        sceneIdx -= value;
    }
}
