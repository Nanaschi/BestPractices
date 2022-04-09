using UnityEngine;
using Zenject;

namespace _Scripts.PlayerPrefs
{
    public class ObstacleClass : MonoBehaviour
    {
        [SerializeField] private OnDamageTakenArgs _onDamageTakenArgs;

        [Inject] private GameEvents _gameEvents;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerStats playerStats))
            {
                /*_gameEvents.OnDamageTaken?.Invoke(this, _onDamageTakenArgs);*/
                _gameEvents.InvokeGameEvent(this, _onDamageTakenArgs);
            }
        }
    }
}
