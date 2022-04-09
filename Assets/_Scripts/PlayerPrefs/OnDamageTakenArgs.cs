
    using System;
    using UnityEngine;

    namespace _Scripts.PlayerPrefs
    {
        [Serializable]
        public class OnDamageTakenArgs: EventArgs
        {
            [SerializeField] private int damageTaken;

            public int DamageTaken => damageTaken;
        }
    }
