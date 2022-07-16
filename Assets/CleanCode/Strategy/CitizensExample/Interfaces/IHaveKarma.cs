using System;

namespace CleanCode.Strategy.CitizensExample
{
    public interface IHaveKarma
    {
        public event Action<float> OnKarmaChanged;
    }
}