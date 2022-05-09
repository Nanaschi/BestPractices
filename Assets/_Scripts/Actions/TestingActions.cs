using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingActions : MonoBehaviour
{
    private event Action _onHealthChanged;

    [SerializeField] private int _currentHealth;
    
    public void ChangeHealth(int healthToChange,
        Action onHealthChanged)
    {
        _currentHealth -= healthToChange;
        onHealthChanged?.Invoke();
    }



}
