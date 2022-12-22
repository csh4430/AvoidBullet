using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public struct TimeData
{
    private float time;
    public float Time
    {
        get => time;
        set
        {
            time = value;
            second = (int)value;
            if(time - 60 >= 0)
            {
                time -= 60;
                minute += 1;
            }
            if(minute - 60 >= 0)
            {
                minute -= 60;
                hour += 1;
            }
        }
    }
    public int hour;
    public int minute;
    public int second;
}

public class ResultData : MonoBehaviour
{
    private static ResultData instance;
    public static ResultData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ResultData>();
            }
            return instance;
        }
    }
    public TimeData time;
    public bool IsNoHit = true;
    [SerializeField] private GameObject _finishObject;
    [SerializeField] private GameObject _crownObject;
    [SerializeField] private TMP_Text TimerText;


    private void Update()
    {
        time.Time += Time.deltaTime;
    }

    public void End()
    {
        SetCrown();
        TimerText.text = $"{(time.hour / 10 >= 1 ? time.hour : "0" + time.hour)}:{(time.minute / 10 >= 1 ? time.minute : "0" + time.minute)}:{(time.second / 10 >= 1 ? time.second : "0" + time.second)}";
        _finishObject.SetActive(true);
        StayUIMgr.Instance.FadeUI.SetIndex(0);
        StayUIMgr.Instance.FadeUI.State = FadeState.FADE_OUT;
    }
    
    public void SetCrown()
    {
        _crownObject.SetActive(IsNoHit);
    }
}