using UnityEngine;
using Zenject;

namespace _Scripts.PlayerPrefs
{
    public class ObstacleClass : MonoBehaviour
    {
        [SerializeField] private OnHealthChangedArgs onHealthChangedArgs;

        [Inject] private GameEventsInject _gameEventsInject;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerStats playerStats))
            {
                _gameEventsInject.InvokeOnDamageTaken(onHealthChangedArgs);
            }
        }
    }
}
