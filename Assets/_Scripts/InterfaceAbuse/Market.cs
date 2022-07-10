using System;
using _Scripts.InterfaceAbuse;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

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

public class PoliticalSituation: ICurrencyChanger
{
    public event Action<float> CurrencyRateChanged;
    public float OnCurrencyRateChangedParameter { get; }
}


public class Bank
{
    private ICurrencyChanger _isCurrencyChanger;
    
    public Bank(ICurrencyChanger isCurrencyChanger)
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


public class WorldBank
{
    
    
    [Inject]
    public WorldBank(Market market)
    {
        var bank = new Bank(market);
    }
}