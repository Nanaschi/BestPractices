using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CitizensView : MonoBehaviour
{
    [SerializeField] private Button _evilCitizenButton;
    [SerializeField] private TextMeshProUGUI _evilCitizebText;
    public event Action OnEvilCitizenButtonClicked;

    #region OnEnable/ OnDisable

    private void OnEnable()
    {
        _evilCitizenButton.onClick.AddListener(EvilCitizenButtonClicked);
    }

    private void OnDisable()
    {
        _evilCitizenButton.onClick.RemoveListener(EvilCitizenButtonClicked);
    }

    #endregion

    public void SetTexts(string[] texts)
    {
        foreach (var text in texts)
        {
            _evilCitizebText.text = String.Concat(text, "/n");
        }
    }
    

    private void EvilCitizenButtonClicked() => OnEvilCitizenButtonClicked?.Invoke();
}
