using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Scripts.PlayerPrefs
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private int _currentAmountOfHealth;
        
        
        [Inject] private GameEvents _gameEvents;
        [Inject] private PersistentData _persistentData;
        
        private int _maximumAmountOfHealth;

        public int MaximumAmountOfHealth => _maximumAmountOfHealth;

        private void OnEnable()
        {
            _gameEvents.OnDamageTaken += ReduceCurrentHealth;
        }


        [SerializeField] private TextMeshProUGUI _textMeshProHealth;
        private void Start()
        {
            _persistentData.LoadFloatData("Current amount of health", _currentAmountOfHealth);
            SetCurrentHealth();
        }

        private void SetCurrentHealth()
        {
            _maximumAmountOfHealth = _currentAmountOfHealth;
            _textMeshProHealth.text = _currentAmountOfHealth.ToString();
        }


        private void ReduceCurrentHealth(object sender, OnDamageTakenArgs onDamageTakenArgs)
        {
            _currentAmountOfHealth -= onDamageTakenArgs.DamageTaken;
            _persistentData.SaveFloatData("Current amount of health", _currentAmountOfHealth);
            _textMeshProHealth.text = _currentAmountOfHealth.ToString();
        }


        private void OnDisable()
        {
            _gameEvents.OnDamageTaken -= ReduceCurrentHealth;
        }
    }
}
