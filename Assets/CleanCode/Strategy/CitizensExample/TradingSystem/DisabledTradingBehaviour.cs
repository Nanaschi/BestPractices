using CleanCode.Strategy.CitizensExample.Interfaces;
using UnityEngine;

namespace CleanCode.Strategy.CitizensExample.TradingSystem
{
    public class DisabledTradingBehaviour: ITradable
    {

        public void Trade(Player player)
        {
            Debug.Log("No trading is available");
        }
    }
}