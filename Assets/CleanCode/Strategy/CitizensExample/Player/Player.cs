using System;
using UnityEngine;
using Zenject;

namespace CleanCode.Strategy.CitizensExample
{
    public class Player : MonoBehaviour, IHaveKarma

    {
    [SerializeField] private float _minKarma, _maxKarma, _currentKarma;
    [SerializeField] private bool _wholeNumbers;
    private PlayerView _playerView;

    public event Action<float> OnKarmaChanged;

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
        _playerView.OnPlayerSliderChanged += ChangeKarma;
    }

    private void OnDisable()
    {
        _playerView.OnPlayerSliderChanged -= ChangeKarma;
    }

    #endregion


    private void ChangeKarma(float karmaAmount)
    {
        _playerView.SetTextValue(karmaAmount);
        _currentKarma = _playerView.GetCurrentSliderValue();
        OnKarmaChanged?.Invoke(karmaAmount);
    }

    
    }
}