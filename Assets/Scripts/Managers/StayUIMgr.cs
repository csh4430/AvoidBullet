using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class StayUIMgr : MonoBehaviour
{
    public FadeUI FadeUI;

    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private Volume _inGameVolume;
    public bool isChanging = false;
    [NonSerialized]
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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuOpen)
                return;
            if (_pauseCanvas.activeInHierarchy && !isChanging)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (_pauseCanvas.activeInHierarchy && Input.GetKeyDown(KeyCode.Return))
        {
            Resume();
            FadeUI.SubIndex(1);
            FadeUI.State = FadeState.FADE_OUT;
        }
    }

    public void Pause()
    {
        isChanging = true;
        _inGameVolume.enabled = true;
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
            _pauseCanvas.SetActive(false);
            _inGameVolume.enabled = false;
        });
    }
}
