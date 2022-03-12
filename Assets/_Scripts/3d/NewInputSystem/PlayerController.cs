using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ThirdPerson
{
    [RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private ThirdPersonPlayerControls _thirdPersonPlayerControls;
    private InputAction _movement;

    private Rigidbody _rigidbody;
    [SerializeField] private float _movementForce = 1;
    [SerializeField] private float _jumpForce = 1;
    [SerializeField] private float _maxSpeed = 5;
  
    private Vector3 _forceDirection = Vector3.zero;
    
    [SerializeField] private Camera _playerCamera;

    private void Awake()
    {
        _thirdPersonPlayerControls = new ThirdPersonPlayerControls();
        InitializeUnityComponents();
    }

    private void InitializeUnityComponents()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        /*print("Movement value " + _movement.ReadValue<Vector2>());*/
        /*_forceDirection += _movement.ReadValue<Vector2>().x * GetCameraRight(_playerCamera);
        _forceDirection += _movement.ReadValue<Vector2>().y * GetCameraForward(_playerCamera);*/
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        throw new NotImplementedException();
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        throw new NotImplementedException();
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

        if (IsGrounded())
        {
            print("Jump performed!");
            _forceDirection += Vector3.up * _jumpForce; 
        }
        
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(transform.position + Vector3.up * .25f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, .3f))
            return true;
        else 
            return false;
    }

    private void OnDisable()
    {
        _thirdPersonPlayerControls.Player.Jump.performed -= Jump; 
        _thirdPersonPlayerControls.Player.Jump.Disable();
        _movement.Disable();
    }
}
}

 
