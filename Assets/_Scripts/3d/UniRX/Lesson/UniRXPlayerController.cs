using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UniRXPlayerController : MonoBehaviour
{

    [SerializeField] private Inputs inputs;
    [SerializeField] private float walkSpeed;
    [SerializeField] private CharacterController _characterController;
    
    private void Start() {
        inputs.Movement
            .Where(v => v != Vector2.zero)
            .Subscribe(inputMovement => {
                var inputVelocity = inputMovement * walkSpeed;

                var playerVelocity =
                    inputVelocity.x * transform.right +
                    inputVelocity.y * transform.forward;

                var distance = playerVelocity * Time.fixedDeltaTime;
                _characterController.Move(distance);
            }).AddTo(this);
    }
}
