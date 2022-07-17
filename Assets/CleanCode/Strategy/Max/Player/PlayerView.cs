using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [FormerlySerializedAs("_playerButton")] [SerializeField] private Slider _playerSlider;
    [FormerlySerializedAs("_playerButton")] [SerializeField] private TextMeshProUGUI _playerSliderText;

    public void SetSliderMinValue(float minValue) => _playerSlider.minValue = minValue;
    public void SetSliderMaxValue(float maxValue) => _playerSlider.maxValue = maxValue;
    public void SetSliderWholeNumbers(bool wholeNumbers) => _playerSlider.wholeNumbers = wholeNumbers;
    public void SetTextValue<T>(T textValue) => _playerSliderText.text = textValue.ToString();
    public float GetCurrentSliderValue() => _playerSlider.value;

    public event Action<float> OnPlayerSliderChanged;

    #region OnEnable/ OnDisable

    private void OnEnable()
    {
        _playerSlider.onValueChanged.AddListener(PlayerSliderChanged);
    }

    private void OnDisable()
    {
        _playerSlider.onValueChanged.RemoveListener(PlayerSliderChanged);
    }

    #endregion

    private void PlayerSliderChanged(float arg0) => OnPlayerSliderChanged?.Invoke(arg0);
}