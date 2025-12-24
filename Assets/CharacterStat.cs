using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public Stat strength;
    public Stat damage;
    public Stat maxHealth;
    public Stat vitality;

    public int currentHealth;

    public System.Action onHealthChanged;
   protected virtual void Start()
    {
        currentHealth = GetMaxHealthValue();

    }
    public virtual void DoDamage(CharacterStat _targetStat)
    {
        //if(_targetStat==null) return;

        int totalDamage=damage.GetValue()+strength.GetValue();
        _targetStat.TakeDamage(totalDamage);
    }

    public virtual void TakeDamage(int _damage)
    {
        DecreaseHealthBy(_damage);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void DecreaseHealthBy(int _damage)
    {
        currentHealth-=_damage;
        if(onHealthChanged != null)
            onHealthChanged?.Invoke();

    }

    protected virtual void Die()
    {
       
    }

    public int GetMaxHealthValue()
    {
        return maxHealth.GetValue();
    }
}
