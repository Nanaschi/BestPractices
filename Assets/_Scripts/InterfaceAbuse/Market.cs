using System;
using _Scripts.InterfaceAbuse;
using UnityEngine;
using UnityEngine.EventSystems;

public class Market : MonoBehaviour, IPointerClickHandler, ICurrencyChanger
{
    private float _onCurrencyRateChangedParameter;
    public event Action<float> CurrencyRateChanged;
    public float OnCurrencyRateChangedParameter
    {
        get => _onCurrencyRateChangedParameter;
        set
        {
            _onCurrencyRateChangedParameter = value;
            OnCurrencyRateChanged(_onCurrencyRateChangedParameter);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnCurrencyRateChangedParameter = 1;
    }


    protected virtual void OnCurrencyRateChanged(float obj)
    {
        CurrencyRateChanged?.Invoke(obj);
    }
}