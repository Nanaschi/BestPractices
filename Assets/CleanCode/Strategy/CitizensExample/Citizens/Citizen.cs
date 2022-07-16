using CleanCode.Strategy.CitizensExample.Interfaces;
using UnityEngine;
using Zenject;

namespace CleanCode.Strategy.CitizensExample
{
    public abstract class Citizen : MonoBehaviour
    {
        protected IMovable _movable;
        protected ISpeakable _speakable;
        protected ITradable _tradable;
        protected CitizensView _citizensView;
        
        [Inject]
        protected abstract void InitializeBehaviours(CitizensView citizensView);


        protected void ChangeTrading(ITradable tradable)
        {
            _tradable = tradable.Equals(_tradable) ? _tradable : tradable;
        }
        public string Trade(Player player)
        {
            return _tradable.Trade(player);
        }

        public string Move()
        {
            return _movable.Move();
        }

        public string Speak(Player player)
        {
            return _speakable.Speak(player);
        }
    }
}