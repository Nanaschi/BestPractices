using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public IObservable<Vector2> Movement { get; set; }
    public IObservable<Vector2> Mouselook { get; private set; }

    private void Awake()
    {
        MovementFixedUpdate();
        MouseInputs();
    }

    private void MouseInputs()
    {
        CursorHandler();
        MouseUpdate();
    }

    private void MouseUpdate()
    {
        // Mouse look ticks on Update
        Mouselook = this.UpdateAsObservable()
            .Select(_ =>
            {
                var x = Input.GetAxis("Mouse X");
                var y = Input.GetAxis("Mouse Y");
                return new Vector2(x, y);
            });
    }

    private static void CursorHandler()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void MovementFixedUpdate()
    {
        Movement = this.FixedUpdateAsObservable()
            .Select(_ =>
            {
                var x = Input.GetAxis("Horizontal");
                var y = Input.GetAxis("Vertical");
                return new Vector2(x, y).normalized;
            });
    }
}
