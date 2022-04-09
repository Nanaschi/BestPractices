using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Scripts.PlayerPrefs
{
    public class PlayerStats : MonoBehaviour
    {
        [FormerlySerializedAs("_amountOfHealth")] [SerializeField] private int _currentAmountOfHealth;
        [Inject] private GameEvents amountOfDamage;
        private int _maximumAmountOfHealth;

        public int MaximumAmountOfHealth => _maximumAmountOfHealth;

        private void OnEnable()
        {
            amountOfDamage.OnDamageTaken += ReduceCurrentHealth;
        }


        [SerializeField] private TextMeshProUGUI _textMeshProHealth;
        private void Start()
        {
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
            _textMeshProHealth.text = _currentAmountOfHealth.ToString();
        }


        private void OnDisable()
        {
            amountOfDamage.OnDamageTaken -= ReduceCurrentHealth;
        }
    }
}
