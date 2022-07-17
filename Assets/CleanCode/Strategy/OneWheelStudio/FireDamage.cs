using UnityEngine;

public class FireDamage: IDoDamage
{
    public void DoDamage(Player player)
    {
        Debug.Log("FireDamage");
    }
}