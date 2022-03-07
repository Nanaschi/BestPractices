using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private PlayerControls _playerControls;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private Vector2 _jumpForce;

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
        _playerControls = new PlayerControls();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerControls.Player.Jump.performed += context => Jump();
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(_jumpForce);
    }
}
