using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ThirdPerson
{
public class PlayerController : MonoBehaviour
{
    private ThirdPersonPlayerControls _thirdPersonPlayerControls;
    private InputAction _movement;

    private void Awake()
    {
        _thirdPersonPlayerControls = new ThirdPersonPlayerControls();
    }

    private void FixedUpdate()
    {
        print("Movement value " + _movement.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _movement = _thirdPersonPlayerControls.Player.Movement;
        _movement.Enable(); //This one is a cached reference to movement. We do it ONLY when we need this InputAction in an Update()
        
        _thirdPersonPlayerControls.Player.Jump.performed += Jump; //Not a cached reference since we do not check it in an update
        _thirdPersonPlayerControls.Player.Jump.Enable();
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        print("Jump performed!");
    }

    private void OnDisable()
    {
        _thirdPersonPlayerControls.Player.Jump.Disable();
        _movement.Disable();
    }
}
}

 
