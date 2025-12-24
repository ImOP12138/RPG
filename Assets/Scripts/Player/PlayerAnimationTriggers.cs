using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player Player=>GetComponentInParent<Player>();
    private void AnimationTrigger()
    {
        Player.AnimationTrigger();
    }

    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(Player.attackCheck.position, Player.attackCheckRadius);

        foreach(var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                EnemyStats _target=hit.GetComponent<EnemyStats>();
                Player.stats.DoDamage(_target);
            }
            if (hit.GetComponent<BatStat>() != null)
            {
                BatStat _target2 = hit.GetComponent<BatStat>();
                Player.stats.DoDamage(_target2);
            }
            if (hit.GetComponentInParent<BossStats>() != null)
            {
                BossStats _target2 = hit.GetComponentInParent<BossStats>();
                Player.stats.DoDamage(_target2);
            }
        }
    }

}
