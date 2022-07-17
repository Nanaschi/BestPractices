using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
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

public interface IDoDamage
{
    void DoDamage(Player player);
}

public class Player
{
}


public class FireDamage: IDoDamage
{
    public void DoDamage(Player player)
    {
        Debug.Log("FireDamage");
    }
}


public class ToxicDamage: IDoDamage
{
    public void DoDamage(Player player)
    {
        Debug.Log("ToxicDamage");
    }
}