using CleanCode.Strategy.CitizensExample.Interfaces;
using UnityEngine;
using Zenject;

namespace CleanCode.Strategy.CitizensExample
{
    public abstract class Citizen : MonoBehaviour
    {
        public IMovable _movable;
        public ISpeakable _speakable;
        public ITradable _tradable;
        private CitizensView _citizensView;
        
        [Inject]
        protected abstract void InitializeBehaviours(CitizensView citizensView);


        public void ChangeTrading(ITradable tradable)
        {
            _tradable = tradable;
        }
        public void Trade(Player player)
        {
            _tradable.Trade(player);
        }

        public void Move()
        {
            _movable.Move();
        }

        public void Speak(Player player)
        {
            _speakable.Speak(player);
        }
    }
}