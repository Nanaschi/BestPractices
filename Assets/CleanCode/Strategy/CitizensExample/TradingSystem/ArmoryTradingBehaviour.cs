using CleanCode.Strategy.CitizensExample.Interfaces;

namespace CleanCode.Strategy.CitizensExample.TradingSystem
{
    public class ArmoryTradingBehaviour: ITradable
    {
        private readonly string _characterKey;
        private readonly ExchangeSystem _exchangeSystem;


        public ArmoryTradingBehaviour(string characterKey, ExchangeSystem exchangeSystem)
        {
            _characterKey = characterKey;
            _exchangeSystem = exchangeSystem;
        }

        public string Trade(Player player)
        {
            _exchangeSystem.OpenArmoryPanel(_characterKey);
            return "I trade armor";
        }
    }
}