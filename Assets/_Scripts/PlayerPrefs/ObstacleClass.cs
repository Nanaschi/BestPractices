using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObstacleClass : MonoBehaviour
{

    [SerializeField] private int _amountOfDamageToTake;

    [Inject] private GameEvents _gameEvents;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerStats playerStats))
        {
            _gameEvents.DamageTaken(_amountOfDamageToTake);
        }
    }
}
