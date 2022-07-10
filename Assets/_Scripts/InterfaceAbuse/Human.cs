using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.InterfaceAbuse;
using UnityEngine;
using UnityEngine.UI;

public class Human : MonoBehaviour
{
    private Image _image;

    [SerializeField] private Market _market;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }


    public event Action OnCurrencyRateChanged;


    private void OnEnable()
    {
        _market.CurrencyRateChanged += ChangeColor;
    }

    private void OnDisable()
    {
        _market.CurrencyRateChanged -= ChangeColor;
    }
    
    
    private void ChangeColor(float obj)
    {
        print($"Color changed and the value is {obj}");
    }
}
