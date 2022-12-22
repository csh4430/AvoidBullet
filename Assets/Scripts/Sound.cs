using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer = null;
    [Header("실행시킬 클립")]
    [SerializeField]
    private List<AudioClip> effAudioClips;
    [SerializeField]
    private List<AudioClip> bgmAudioClips = new List<AudioClip>();
    [Header("오디오 믹서 그룹")]
    [SerializeField]
    private AudioMixerGroup bgmMixerGroup;
    [SerializeField]
    private AudioMixerGroup effMixerGroup;

    private static List<AudioSource> SoundsEff = new List<AudioSource>();
    private static List<AudioSource> SoundsBgm = new List<AudioSource>();

    //exposed parameters의 파라미터들의 이름.
    private string bgm_Group = "Music";
    private string eff_Group = "Effect";
    private string master_Group = "Master";

    private static AudioSource lastPlayBgm;
    private void Awake()
    {
        SetSource();
    }
    public static void PlayBgm(SoundType.BgmType value)
    {
        //Debug.Log("play Bgm");
        lastPlayBgm?.Stop();
        SoundsBgm[(int)value].Play();
        lastPlayBgm = SoundsBgm[(int)value];
    }
    public static void PlayEff(SoundType.EffType value, bool isLoop = false)
    {
        //Debug.Log("play eff");
        if (isLoop)
            SoundsEff[(int)value].loop = true;
        else
            SoundsEff[(int)value].loop = false;
        SoundsEff[(int)value].Play();
    }
    public static void StopEff(SoundType.EffType value)
    {
        SoundsEff[(int)value].Stop();
    }
    private void SetSource()
    {
        int i = 1;
        foreach (AudioClip clip in effAudioClips)
        {
            var obj = new GameObject().AddComponent<AudioSource>();
            obj.name = "Eff " + i;
            obj.playOnAwake = false;
            obj.outputAudioMixerGroup = effMixerGroup;
            obj.clip = clip;
            SoundsEff.Add(obj);
            obj.transform.SetParent(this.transform);
            i++;
        }
        i = 1;
        foreach (AudioClip clip in bgmAudioClips)
        {
            var obj = new GameObject().AddComponent<AudioSource>();
            obj.name = "Bgm " + i;
            obj.playOnAwake = false;
            obj.clip = clip;
            obj.loop = true;
            obj.outputAudioMixerGroup = bgmMixerGroup;

            SoundsBgm.Add(obj);
            obj.transform.SetParent(this.transform);
            i++;
        }

    }
}
