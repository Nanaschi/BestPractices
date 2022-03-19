using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CubeTween : MonoBehaviour
{
    [SerializeField] private float _moveDuration;
    [SerializeField] private float _rotateDuration;
    [SerializeField] private Vector3 _vector3Move;
    [SerializeField] private Vector3 _vector3Rotate;
    private void Start()
    {
        TweenMotions();
    }

    private void TweenMotions()
    {
        transform.DOMove(_vector3Move, _moveDuration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        transform.DORotate(_vector3Rotate, _rotateDuration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);
    }
}
