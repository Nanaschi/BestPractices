using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UniRxInput : MonoBehaviour
{
    private CompositeDisposable _disposable = new CompositeDisposable();
    private void Awake()
    {
        TrippleClickLogic();
    }

    private static void TrippleClickLogic()
    {
        var clickStream = Observable.EveryUpdate() // creating stream (in UniRX they called Observables) form update events
            .Where(_ => Input.GetMouseButtonDown(0)); // filtering to the new stream of touch events

        clickStream
            .Buffer(clickStream.Throttle(
                TimeSpan.FromMilliseconds(250))) // gather click events which happens within 250 milliseconds into bundles
            .Where(xs => xs.Count >= 3) // filtering bundles with more that 3 click events into a new stream
            .Subscribe(xs =>
                Debug.Log("Triple click detected! Count:" + xs.Count)); // listening to resulting triple click stream
    }

    private void Start()
    {
        Observable.EveryUpdate().Subscribe(_ => { Debug.Log("UniRx Update");}).AddTo(_disposable);
    }

    public void OnDisable()
    {
        _disposable?.Dispose();
    }
}
