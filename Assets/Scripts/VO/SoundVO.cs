using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SoundVO
{
    public float MasterVolume ;
    public float MusicVolume ;
    public float EffectVolume ;
    
    public SoundVO()
    {
        MasterVolume = 1f;
        MusicVolume = 1f;
        EffectVolume = 1f;
    }

    public SoundVO(float masterVolume, float musicVolume, float effectVolume)
    {
        MasterVolume = masterVolume;
        MusicVolume = musicVolume;
        EffectVolume = effectVolume;
    }

    public float  GetVolume(int i)
    {
        return i switch
        {
            0 => MasterVolume,
            1 => MusicVolume,
            2 => EffectVolume,
            _ => 0
        };
    }
    
    public void SetVolume(int i, float value)
    {
        switch (i)
        {
            case 0:
                MasterVolume = value;
                break;
            case 1:
                MusicVolume = value;
                break;
            case 2:
                EffectVolume = value;
                break;
        }
        DataManager.SaveJsonFile($"{Application.dataPath}/Data", "Sound", DataManager.ObjectToJson(this));
    }
}
