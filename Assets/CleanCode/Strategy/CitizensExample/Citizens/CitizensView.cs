using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CitizensView : MonoBehaviour
{
    [SerializeField] private Button _evilCitizenButton;

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


    private void EvilCitizenButtonClicked() => OnEvilCitizenButtonClicked?.Invoke();
}
