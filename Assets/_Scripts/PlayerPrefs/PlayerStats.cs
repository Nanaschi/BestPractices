using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Scripts.PlayerPrefs
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private PlayerModel _playerModel;
        
        [Inject] private GameEventsInject _gameEventsInject;

        [Inject] private PersistentDataInject _persistentDataInject;

        private int _maximumAmountOfHealth;


        private const string CurrentHealth = "Current health";

        public int MaximumAmountOfHealth => _maximumAmountOfHealth;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F5))
            {
                _persistentDataInject.SaveFloatData
                    (CurrentHealth, _playerModel.CurrentAmountOfHealth);
            } else if(Input.GetKeyDown(KeyCode.F9))
            {
                _playerModel.CurrentAmountOfHealth =
                    (int) _persistentDataInject.LoadFloatData
                        (CurrentHealth, _playerModel.CurrentAmountOfHealth);
                SetCurrentHealth(_playerModel);
            }
        }

        private void OnEnable()
        {
            _gameEventsInject.OnDamageTaken += ReduceCurrentHealth;
            _gameEventsInject.OnSave += SetCurrentHealth;
        }
        [SerializeField] private TextMeshProUGUI _textMeshProHealth;
        private void Start()
        {
            SetMaximumAmountOfHealth();
            SetCurrentHealth(_playerModel);
        }

        private void SetCurrentHealth(PlayerModel playerModel)
        {
            _textMeshProHealth.text = playerModel.CurrentAmountOfHealth.ToString();
        }

        private void SetMaximumAmountOfHealth()
        {
            _maximumAmountOfHealth =  _playerModel.CurrentAmountOfHealth;
        }


        private void ReduceCurrentHealth(OnHealthChangedArgs onHealthChangedArgs)
        {
            _playerModel.CurrentAmountOfHealth -= onHealthChangedArgs.AmouneOfHealthChanged;
            _textMeshProHealth.text =  _playerModel.CurrentAmountOfHealth.ToString();
        }


        private void OnDisable()
        {
            _gameEventsInject.OnDamageTaken -= ReduceCurrentHealth;
        }
    }
}
