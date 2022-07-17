using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    protected IDoDamage _doDamage;

    protected void TryDoAttack(Player player)
    {
        _doDamage?.DoDamage(player);
    }


    protected void ChangeIDoDamage(IDoDamage doDamage)
    {
        _doDamage = doDamage;
    }

    protected void DoDamage(Player player)
    {
        _doDamage.DoDamage(player);
    }
}