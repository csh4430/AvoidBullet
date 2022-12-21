using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MenuSetting : Menu
{
    public List<PointUI> points = new List<PointUI>();
    private int _pointIdx = 0;
    private SoundVO _sound;
    public UniversalRendererData rendererData;
    public override void Interactive()
    {
        IsOpen = true;
        StartSceneMgr.Sound.PlayEff(SoundType.EffType.ClickBtn);
    }

    public override void Deinteractive()
    {
        IsOpen = false;
        StartSceneMgr.Sound.PlayEff(SoundType.EffType.ClickBtn);
    }

    public override void Start()
    {
        _sound = DataManager.LoadJsonFile<SoundVO>($"{Application.dataPath}/Data","Sound");
        
        for (int i = 0; i < points.Count - 1; i++)
        {
            ((SliderUI)points[i]._selectedUI).Value  = _sound.GetVolume(i);
        }

        ((TogleUI)points[points.Count - 1]._selectedUI).Value = !rendererData.rendererFeatures[0].isActive;
        SoundManager._Sound = _sound;
        
    }

    public override void Update()
    {
        if (IsOpen is false)
        {
            points[_pointIdx]._isPointActive = false;
            _pointIdx = 0;
            return;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
            _pointIdx = (_pointIdx + points.Count - 1) % points.Count;
        if(Input.GetKeyDown(KeyCode.DownArrow))
            _pointIdx = (_pointIdx + 1) % points.Count;
        if (points[_pointIdx]._selectedUI is SliderUI)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                ((SliderUI)points[_pointIdx]._selectedUI).Value -= 0.005f;
                _sound.SetVolume(_pointIdx, ((SliderUI)points[_pointIdx]._selectedUI).Value);
                SoundManager._Sound = _sound;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                ((SliderUI)points[_pointIdx]._selectedUI).Value += 0.005f;
                _sound.SetVolume(_pointIdx, ((SliderUI)points[_pointIdx]._selectedUI).Value);
                SoundManager._Sound = _sound;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            ((TogleUI)points[_pointIdx]._selectedUI).Value = !((TogleUI)points[_pointIdx]._selectedUI).Value;
            rendererData.rendererFeatures[0].SetActive(!((TogleUI)points[_pointIdx]._selectedUI).Value);
        }
        
        for(var i = 0; i < points.Count; i++)
        {
            points[i]._isPointActive = i == _pointIdx;
        }
    }
}
