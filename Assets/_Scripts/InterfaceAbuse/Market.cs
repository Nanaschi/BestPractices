using System;
using _Scripts.InterfaceAbuse;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Zenject;

public class Market : MonoBehaviour, IPointerClickHandler, ICurrencyChanger
{
    private float _onCurrencyRateChangedParameter;
    public event Action<float> CurrencyRateChanged;
    public event Action CurrencyRateChanged2;


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

public class AmericanBank: ICurrencyChanger
{
    private ICurrencyChanger _isCurrencyChanger;
    public event Action<float> CurrencyRateChanged;
    public event Action CurrencyRateChanged2;
    public float OnCurrencyRateChangedParameter { get; }


    private Market _market;
    
    [Inject]
    public AmericanBank(ICurrencyChanger isCurrencyChanger)
    {
        _isCurrencyChanger = isCurrencyChanger;
        Subscribe();
    }

    private void Subscribe()
    {
        _isCurrencyChanger.CurrencyRateChanged += Something;
    }

    private void Something(float obj)
    {
        throw new NotImplementedException();
    }
}


public class CanadianBank: ICurrencyChanger
{
    [Inject]
    public CanadianBank(Market isCurrencyChanger)
    {

        Subscribe();
    }

    private void Subscribe()
    {
        CurrencyRateChanged += Something;
    }

    private void Something(float obj)
    {
        throw new NotImplementedException();
    }

    public event Action<float> CurrencyRateChanged;
    public event Action CurrencyRateChanged2;
    public float OnCurrencyRateChangedParameter { get; }
}


public class WorldBank
{
    public WorldBank(Market market)
    {
        var bank = new CanadianBank(market);
        var polSIt = new AmericanBank(market);
    }
}