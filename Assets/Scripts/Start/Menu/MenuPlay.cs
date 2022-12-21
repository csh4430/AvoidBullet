using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlay : Menu
{
    public override void Interactive()
    {
        StartSceneMgr.Sound.PlayEff(SoundType.EffType.LoadScene);
        StartSceneMgr._fadeUI.SetIndex(1);
        StartSceneMgr._fadeUI.State = FadeState.FADE_OUT;
        DOTween.KillAll();
    }
}
