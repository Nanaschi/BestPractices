using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public event Action<int> OnDamageTaken;


    public void DamageTaken(int amountOfDamage)
    {
        OnDamageTaken?.Invoke(amountOfDamage);
    }
}
