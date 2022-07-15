using CleanCode.Strategy.CitizensExample.Interfaces;

namespace CleanCode.Strategy.CitizensExample.TradingSystem
{
    public class SupplyTradingBehaviour: ITradable
    {
        
        private readonly string _characterKey;
        private readonly ExchangeSystem _exchangeSystem;


        SupplyTradingBehaviour(string characterKey, ExchangeSystem exchangeSystem)
        {
            _characterKey = characterKey;
            _exchangeSystem = exchangeSystem;
        }
        
        public void Trade(Player player)
        {
            _exchangeSystem.OpenSupplyPanel(_characterKey);
        }
    }
}