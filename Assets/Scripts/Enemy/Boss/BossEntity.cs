using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEntity : Entity
{
    
    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
        
        
    }
}
