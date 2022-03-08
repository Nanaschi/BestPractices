using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private PlayerControls _playerControls;
    private Vector2 _moveDirection;
    [SerializeField] [Range(0, 500)] private int _playerSpeed;
    [SerializeField] [Range(0, 500)] private int _jumpForce;
    

    private void OnEnable()
    {
        _playerControls.Player.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Player.Disable();
    }

    private void Awake()
    {
        UnityComponentsInitialization();
        InputSystemInitialization();
    }

    private void InputSystemInitialization()
    {
        _playerControls = new PlayerControls();
        _playerControls.Player.Jump.performed += context => Jump();
        _playerControls.Player.Move.performed += context => _moveDirection = context.ReadValue<Vector2>();
    }
    

    private void UnityComponentsInitialization()
    {
        
    }

    private void Jump()
    {
        transform.Translate(Vector2.up * _jumpForce);
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _playerSpeed);
    }
}
