using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.PlayerPrefs;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class UniRXPlayerController : MonoBehaviour
{

    [Inject] private Inputs inputs;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private float walkSpeed;
    [FormerlySerializedAs("currentRunSpeed")] [FormerlySerializedAs("runSpeed")] [SerializeField] private float _currentRunSpeed;
    private float _maximumRunSpeed;
    [Range(-90, 0)]
    public float minViewAngle = -60f; // How much can the user look down (in degrees)
    [Range(0, 90)]
    public float maxViewAngle = 60f; 
    [Range(0, 90)]
    public float _cameraSensitivity; // How much can the user look up (in degrees)

    private CharacterController _characterController;
    [SerializeField] private Camera _camera;
    [Inject] private GameEvents _gameEvents;


    private void OnEnable()
    {
        _gameEvents.OnDamageTaken += ReduceRunSpeed;
    }

    private void OnDisable()
    {
        _gameEvents.OnDamageTaken -= ReduceRunSpeed;
    }

    private void Awake()
    {
        _maximumRunSpeed = _currentRunSpeed;
        UnityComponentInitialization();
    }

    private void UnityComponentInitialization()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Start() {
        inputs.Movement
            .Where(v => v != Vector2.zero)
            .Subscribe(Movement)
            .AddTo(this);
        
        
        
        // Handle mouse input (free mouse look).
        inputs.Mouselook
            .Where(v => v != Vector2.zero) // We can ignore this if mouse look is zero.
            .Subscribe(MouseMovement)
            .AddTo(this);
    }

    private void MouseMovement(Vector2 inputLook)
    {
        // Translate 2D mouse input into euler angle rotations.

        // inputLook.x rotates the character around the vertical axis (with + being right)
        var horzLook = inputLook.x * Time.deltaTime * Vector3.up *_cameraSensitivity;
        transform.localRotation *= Quaternion.Euler(horzLook);

        // inputLook.y rotates the camera around the horizontal axis (with + being up)
        var vertLook = inputLook.y * Time.deltaTime * Vector3.left*_cameraSensitivity;
        var newQ = _camera.transform.localRotation * Quaternion.Euler(vertLook);

        // We have to flip the signs and positions of min/max view angle here because the math
        // uses the contradictory interpretation of our angles (+/- is down/up).
        _camera.transform.localRotation = ClampRotationAroundXAxis(newQ, -maxViewAngle, -minViewAngle);
    }

    private void Movement(Vector2 inputMovement)
    {
        
        var inputVelocity = inputMovement *
                            (inputs.Run.Value ? _currentRunSpeed : walkSpeed);

        var playerVelocity =
            inputVelocity.x * transform.right +
            inputVelocity.y * transform.forward;

        var distance = playerVelocity * Time.fixedDeltaTime;
        _characterController.Move(distance);
    }
    
    
    
    // Ripped straight out of the Standard Assets MouseLook script. (This should really be a standard function...)
    private static Quaternion ClampRotationAroundXAxis(Quaternion q, float minAngle, float maxAngle) {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, minAngle, maxAngle);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
    

    private void ReduceRunSpeed(object sender, OnDamageTakenArgs onDamageTakenArgs)
    {
        _currentRunSpeed -=  onDamageTakenArgs.DamageTaken * _maximumRunSpeed/_playerStats.MaximumAmountOfHealth;
    }
}
