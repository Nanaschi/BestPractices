using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AssaultRifle : MonoBehaviour
{
    [SerializeField] private TestingActions _testingActions;
    
    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            _testingActions.ChangeHealth(5, () => print("health left is "));
        }
    }
}
