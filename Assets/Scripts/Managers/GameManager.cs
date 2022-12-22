using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private Volume _inGameVolume;
    private Dictionary<Type, Manager> managers;
    public bool isChanging = false;
    private static GameManager _instance = null;
    private Sequence seq;
    private ColorAdjustments adjustments;
    private Sound sound;
    public static GameManager Instance
    {
        get
        {
            if (_instance is not null) return _instance;
            _instance = GameObject.FindObjectOfType<GameManager>() ?? new GameObject("GameManager").AddComponent<GameManager>();
            return _instance;
        }
    }
    public T AddManager<T> () where T : Manager, new()
    {
        var manager = new T();
        managers.Add(typeof(T), manager);
        return manager;
    }
    
    public T GetManager<T> () where T : Manager
    {
        if (managers.TryGetValue(typeof(T), out var manager))
        {
            return manager as T;
        }
        return null;
    }
    
    
    private void Awake()
    {
        managers = new Dictionary<Type, Manager>();
        AddManager<MapManager>();
        AddManager<PoolManager>();
        AddManager<UIManager>().StayUIMgr.FadeUI.State = FadeState.FADE_IN;
        sound = FindObjectOfType<Sound>();
    }

    private void Start()
    {
        _inGameVolume.profile.TryGet(out adjustments);
        sound.PlayBgm(SoundType.BgmType.Tuto);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pauseCanvas.activeInHierarchy && !isChanging)
            {
                isChanging = true;
                seq = DOTween.Sequence();
                seq.SetUpdate(true);
                seq.Append(DOTween.To(() => Time.timeScale, (t) => Time.timeScale = t, 1, 0.2f));
                seq.Join(DOTween.To(() => adjustments.saturation.value, (t) => adjustments.saturation.value = t, 0, 0.2f));
                seq.AppendCallback(() =>
                {
                    isChanging = false;
                    seq.Kill();
                    _pauseCanvas.SetActive(false);
                });
            }
            else
            {
                isChanging = true;
                seq = DOTween.Sequence();
                _pauseCanvas.SetActive(true);
                seq.SetUpdate(true);
                seq.Append(DOTween.To(() => Time.timeScale, (t) => Time.timeScale = t, 0, 0.5f));
                seq.Join(DOTween.To(() => adjustments.saturation.value, (t) => adjustments.saturation.value = t, -100, 0.5f));
                seq.AppendCallback(() =>
                {
                    isChanging = false;
                    seq.Kill();
                });
            }
        }
    }
}
