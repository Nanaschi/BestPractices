
    using System;
    using UnityEngine;

    namespace _Scripts.PlayerPrefs
    {
        [Serializable]
        public class OnHealthChangedArgs: EventArgs
        {
            [SerializeField] private int amouneOfHealthChanged;

            public int AmouneOfHealthChanged => amouneOfHealthChanged;
        }
    }
