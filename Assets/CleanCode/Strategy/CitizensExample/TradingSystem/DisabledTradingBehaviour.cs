using CleanCode.Strategy.CitizensExample.Interfaces;

namespace CleanCode.Strategy.CitizensExample.TradingSystem
{
    public class DisabledTradingBehaviour: ITradable
    {

        public void Trade(Player player)
        {
            throw new System.NotImplementedException();
        }
    }
}