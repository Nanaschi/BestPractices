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