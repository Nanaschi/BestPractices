using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _amountOfHealth;
    [Inject] private GameEvents amountOfDamage;

    private void OnEnable()
    {
        amountOfDamage.OnDamageTaken += ReduceCurrentHealth;
    }


    [SerializeField] private TextMeshProUGUI _textMeshProHealth;
    private void Start()
    {
        SetCurrentHealth();
    }

    private void SetCurrentHealth()
    {
        _textMeshProHealth.text = _amountOfHealth.ToString();
    }


    private void ReduceCurrentHealth(int amountOfDamageTaken)
    {
        _amountOfHealth -= amountOfDamageTaken;
        _textMeshProHealth.text = _amountOfHealth.ToString();
    }


    private void OnDisable()
    {
        amountOfDamage.OnDamageTaken -= ReduceCurrentHealth;
    }
}
