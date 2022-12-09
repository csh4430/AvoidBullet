using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private int idx = 0;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            Rotate();
    }

    private void Rotate()
    {
        idx = (idx + 1) % 4;
        transform.DORotate(new Vector3(0, 90 * idx, 0), 1f);
    }
}
