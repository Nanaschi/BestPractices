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
                _gameEvents.OnDamageTaken(this, _onDamageTakenArgs);
            }
        }
    }
}
