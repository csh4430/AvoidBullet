using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIFading : UIBehaviour
{
    private Image thisImage;
    public float Duration = 1f;

    public override void Awake()
    {
        thisImage = ThisUI.GetComponent<Image>();
    }

    public void FadeIn()
    {
        thisImage.DOFade(0, Duration).SetEase(Ease.InSine);
    }
    
    public void FadeOut(int sceneIdx)
    {
        thisImage.DOFade(1, Duration).SetEase(Ease.OutSine).OnComplete(() =>
        {
            if(sceneIdx == -1)
            {
                Application.Quit();
                DOTween.KillAll();
                return;
            }
            SceneManager.LoadScene(sceneIdx);
            DOTween.KillAll();
            FadeIn();
        });
    }
}
