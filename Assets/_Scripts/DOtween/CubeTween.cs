using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CubeTween : MonoBehaviour
{
    [SerializeField] private float _moveDuration;
    [SerializeField] private Vector3 _vector3Move;
    private void Start()
    {
        transform.DOMove(_vector3Move, _moveDuration);
    }
}
