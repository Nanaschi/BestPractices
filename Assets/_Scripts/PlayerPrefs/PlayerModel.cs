using System;
using UnityEngine;

namespace _Scripts.PlayerPrefs
{
    [Serializable]
    public class PlayerModel: EventArgs
    {
        [SerializeField] private int _currentAmountOfHealth;

        public int CurrentAmountOfHealth
        {
            get => _currentAmountOfHealth;
            set => _currentAmountOfHealth = value;
        }
    }
}