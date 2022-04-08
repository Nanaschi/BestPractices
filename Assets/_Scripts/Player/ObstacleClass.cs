using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleClass : MonoBehaviour
{

    [SerializeField] private int _amountOfDamageToTake;
    
    private event Action<int> _damageTaken;
    private void OnTriggerEnter(Collider other)
    {
        if (TryGetComponent(out PlayerStats playerStats))
        {
            _damageTaken?.Invoke(_amountOfDamageToTake);
        }
    }
}
