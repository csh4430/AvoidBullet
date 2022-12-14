using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class RotateCamera : MonoBehaviour
{
    public static void Rotate(int idx)
    {
        Camera.main.transform.DORotate(new Vector3(0, 90 * idx, 0), 0.7f);
    }
}
