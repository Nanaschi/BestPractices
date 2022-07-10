using System;

namespace _Scripts.InterfaceAbuse
{
    public interface ICurrencyChanger
    {
        event Action<float> CurrencyRateChanged;

        public float OnCurrencyRateChangedParameter
        {
            get;
        }

    }
}