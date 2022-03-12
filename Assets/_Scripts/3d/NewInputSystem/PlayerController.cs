using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ThirdPerson
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    private ThirdPersonPlayerControls _thirdPersonPlayerControls;
    private InputAction _movement;

    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;
    
    [SerializeField] private float _movementForce = 1;
    [SerializeField] private float _jumpForce = 1;

    private Vector3 _forceDirection = Vector3.zero;
    

    private void Awake()
    {
        _thirdPersonPlayerControls = new ThirdPersonPlayerControls();
        InitializeUnityComponents();
    }

    private void InitializeUnityComponents()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void FixedUpdate()
    {
        print("Movement value " + _movement.ReadValue<Vector2>());
        _rigidbody.velocity = new Vector3(_movement.ReadValue<Vector2>().x, 0 ,_movement.ReadValue<Vector2>().y) * _movementForce;
    }

    private void OnEnable()
    {
        NewInputOnEnable();

     
        _boxCollider.OnTriggerEnterAsObservable().
            Skip(1).
            Where(trigger => trigger.GetComponent(typeof(IImpenetrable)))
            .Subscribe(_ =>
        {
            
        });

    }

    private void NewInputOnEnable()
    {
        _movement = _thirdPersonPlayerControls.Player.Movement;
        _movement.Enable(); //This one is a cached reference to movement. We do it ONLY when we need this InputAction in an Update()

        _thirdPersonPlayerControls.Player.Jump.performed +=
            Jump; //Not a cached reference since we do not check it in an update
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

 
