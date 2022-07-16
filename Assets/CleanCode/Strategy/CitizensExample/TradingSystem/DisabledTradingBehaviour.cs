using CleanCode.Strategy.CitizensExample.Interfaces;
using UnityEngine;

namespace CleanCode.Strategy.CitizensExample.TradingSystem
{
    public class DisabledTradingBehaviour: ITradable
    {

        public string Trade(Player player)
        {
            return "No trading is available";
        }
    }
}