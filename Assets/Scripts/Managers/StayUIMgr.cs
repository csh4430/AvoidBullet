using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class StayUIMgr : MonoBehaviour
{
    
    private static StayUIMgr _instance;
    public static StayUIMgr Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<StayUIMgr>();
            }
            return _instance;
        }
    }
    public FadeUI FadeUI;

    [SerializeField] private GameObject _pauseObject;
    [SerializeField] private GameObject _rewindObject;
    [SerializeField] private Volume _inGameVolume;
    public bool isChanging = false;
    public bool isMenuOpen = false;
    private Sequence seq;
    private ColorAdjustments adjustments;



    private void Awake()
    {
        if (GameObject.FindObjectOfType<StayUIMgr>() != this)
        {
            gameObject.SetActive(false);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Start()
    {
        _inGameVolume.profile.TryGet(out adjustments);
    }
    private void Update()
    {
        if (isMenuOpen)
            return;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (_pauseObject.activeInHierarchy && !isChanging)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        
    }

    private void LateUpdate()
    {
        if (_pauseObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Return))
        {
            Resume();
            FadeUI.SubIndex(1);
            FadeUI.State = FadeState.FADE_OUT;
        }
    }

    public void Pause()
    {
        if (isMenuOpen)
            return;
        isChanging = true;
        _inGameVolume.enabled = true;
        seq = DOTween.Sequence();
        _pauseObject.SetActive(true);
        seq.SetUpdate(true);
        seq.Append(DOTween.To(() => Time.timeScale, (t) => Time.timeScale = t, 0, 0.5f));
        seq.Join(DOTween.To(() => adjustments.saturation.value, (t) => adjustments.saturation.value = t, -100, 0.5f));
        seq.AppendCallback(() =>
        {
            isChanging = false;
            seq.Kill();
        });
    }

    public void Resume()
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
            _pauseObject.SetActive(false);
            _inGameVolume.enabled = false;
        });
    }

    public void Restart()
    {
        FadeUI.SetIndex(0);
        _rewindObject.SetActive(true);
        FadeUI.State = FadeState.FADE_OUT;
    }
}
