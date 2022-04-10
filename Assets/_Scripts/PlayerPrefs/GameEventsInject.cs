using System;
using UnityEngine;

namespace _Scripts.PlayerPrefs
{
    public class GameEventsInject : MonoBehaviour
    {
        public Action<OnHealthChangedArgs> OnDamageTaken { get; set; }
        public Action<PlayerModel> OnSave { get; set; }
        public Action<PlayerModel> OnLoad { get; set; }

        public void InvokeOnDamageTaken (OnHealthChangedArgs eventArgs)
        {
            OnDamageTaken?.Invoke(eventArgs);
        }
        
        public void InvokeOnSave(PlayerModel eventArgs)
        {
            print("Save invoked?");
            OnSave?.Invoke(eventArgs);
        }    
        
        public void InvokeOnLoad(PlayerModel eventArgs)
        {
            print("Load invoked?");
            OnLoad?.Invoke(eventArgs);
        }
        
    }
}
