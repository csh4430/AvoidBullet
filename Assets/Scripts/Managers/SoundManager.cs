using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;

public static class SoundManager
{
    private static SoundVO _soundVo;

    public static SoundVO _Sound
    {
        get => _soundVo;
        set
        {
            _soundVo = value;
            Debug.Log($"{_soundVo.MasterVolume}, {_soundVo.MusicVolume}, {_soundVo.EffectVolume}");
            audioMixer.SetFloat("Master", Mathf.Log10(_soundVo.MasterVolume) * 20);
            audioMixer.SetFloat("Music", Mathf.Log10(_soundVo.MusicVolume) * 20);
            audioMixer.SetFloat("Effect", Mathf.Log10(_soundVo.EffectVolume) * 20);
        }
    }
    
    private static AudioMixer _audioMixer;
    public static AudioMixer audioMixer => _audioMixer ?? (_audioMixer = Resources.Load("Sound/MainAudioMixer") as AudioMixer);
}
