using System.Collections;
using UnityEngine;

public class FireWeapon : BaseWeapon
{
    private Player _player;
    
    private void Awake()
    {
        _doDamage = new FireDamage();
        _player = new Player();
    }

    private void Start()
    {
        DoDamage(_player);
        StartCoroutine(ActivateToxic());
    }

    IEnumerator ActivateToxic()
    {
        yield return new WaitForSeconds(5);
        ChangeIDoDamage(new ToxicDamage());
        DoDamage(_player);
    }
}