using System;
using UnityEngine;

namespace _Scripts.PlayerPrefs
{
    public class GameEvents : MonoBehaviour
    {
        public EventHandler<OnDamageTakenArgs> OnDamageTaken;
    }
}
