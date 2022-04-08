using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _amountOfHealth;

    public int AmountOfHealth
    {
        get => _amountOfHealth;
        set => _amountOfHealth = value;
    }

    private void OnEnable()
    {
        
    }


    [SerializeField] private TextMeshProUGUI _textMeshProHealth;
    private void Start()
    {
        _textMeshProHealth.text = _amountOfHealth.ToString();
    }
}
