using UnityEngine;

public class ToxicDamage: IDoDamage
{
    public void DoDamage(Player player)
    {
        Debug.Log("ToxicDamage");
    }
}