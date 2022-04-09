using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class PlayerStats : MonoBehaviour
{
    [FormerlySerializedAs("_amountOfHealth")] [SerializeField] private int _currentAmountOfHealth;
    [Inject] private GameEvents amountOfDamage;
    private int _maximumAmountOfHealth;

    public int MaximumAmountOfHealth => _maximumAmountOfHealth;

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
        _maximumAmountOfHealth = _currentAmountOfHealth;
        _textMeshProHealth.text = _currentAmountOfHealth.ToString();
    }


    private void ReduceCurrentHealth(int amountOfDamageTaken)
    {
        _currentAmountOfHealth -= amountOfDamageTaken;
        _textMeshProHealth.text = _currentAmountOfHealth.ToString();
    }


    private void OnDisable()
    {
        amountOfDamage.OnDamageTaken -= ReduceCurrentHealth;
    }
}
