using System;
using UnityEngine;
using Zenject;

namespace CleanCode.Strategy.CitizensExample
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _minKarma, _maxKarma;
        [SerializeField] private bool _wholeNumbers;
        private PlayerView _playerView;

        [Inject]
        public void Initialize(PlayerView playerView)
        {
            _playerView = playerView;
            _playerView.SetSliderMinValue(_minKarma);
            _playerView.SetSliderMaxValue(_maxKarma);
            _playerView.SetSliderWholeNumbers(_wholeNumbers);
            _playerView.SetTextValue(_minKarma);
        }

        #region OnEnable/ OnDisable

        private void OnEnable()
        {
            _playerView.OnPlayerSliderChanged += GiveValue;
        }
        private void OnDisable()
        {
            _playerView.OnPlayerSliderChanged -= GiveValue;
        }

        #endregion


        private void GiveValue(float obj)
        {
            _playerView.SetTextValue(obj);
        }

       
    }
}