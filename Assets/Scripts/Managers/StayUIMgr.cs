using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayUIMgr : MonoBehaviour
{
    public FadeUI FadeUI;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
