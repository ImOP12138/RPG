using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatStat : CharacterStat
{
    private SmartBat bat;
    public EntityFX fx { get; private set; }
    protected override void Start()
    {
        fx=GetComponent<EntityFX>();
        base.Start();
        bat = GetComponent<SmartBat>();
    }

    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);
        fx.StartCoroutine("FlashFX");
        //StartCoroutine("HitKnockback");
    }
    protected override void Die()
    {
        base.Die();
        bat.Die();

    }



}
