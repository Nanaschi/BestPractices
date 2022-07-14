using System;

namespace _Scripts.InterfaceAbuse
{
    public interface ICurrencyChanger
    {
        event Action<float> CurrencyRateChanged;
        event Action CurrencyRateChanged2;

        public float OnCurrencyRateChangedParameter
        {
            get;
        }
        
        
        
        public float OnCurrencyRateChangedParameter1 => 2;
        
    }
}