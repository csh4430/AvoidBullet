using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultData : MonoBehaviour
{
    public float FinishTime;
    public bool IsNoHit;
    [SerializeField] private GameObject _crownObject;

    public void SetStartTime()
    {
        FinishTime = Time.time;
    }

    public void SetEndTime()
    {
        FinishTime = Time.time - FinishTime;
    }
}