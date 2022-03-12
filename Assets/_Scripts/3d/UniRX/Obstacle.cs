using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Obstacle : MonoBehaviour, IImpenetrable
{
    private ReactiveProperty<bool> _collided = new ReactiveProperty<bool>();

    private void OnEnable()
    {
        _collided.Where(_collided => _collided == true).
            Subscribe(_ =>
        {
            print("Collided!");
        });
    }

    public void Collide()
    {
        _collided.Value = true;

    }
}
