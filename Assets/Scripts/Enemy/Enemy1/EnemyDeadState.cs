using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyState
{
    private Enemy_Skeleton enemy;
    public EnemyDeadState(Enemy enemyBase, EnemyStateMachine stateMachine,  string animBoolName,Enemy_Skeleton _enemy) : base(enemyBase, stateMachine,  animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.anim.SetBool(enemy.lastAnimBoolName, true);
        enemy.anim.speed = 0;
        enemy.cd.enabled = false;
        stateTimer = .1f;
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer > 0)
            rb.velocity = new Vector2(0, 10);
    }
}
