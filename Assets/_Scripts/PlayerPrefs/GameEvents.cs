using System;
using UnityEngine;

namespace _Scripts.PlayerPrefs
{
    public class GameEvents : MonoBehaviour
    {
        public EventHandler<OnDamageTakenArgs> OnDamageTaken { get; set; }


        public void InvokeOnDamageTaken (object sender, EventArgs eventArgs)
        {
            OnDamageTaken?.Invoke((GameObject)sender, (OnDamageTakenArgs) eventArgs);
        }
    }
}
