using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStunedState : EnemyState
{
    private Enemy_Skeleton enemy;
    public EnemyStunedState(Enemy enemyBase, EnemyStateMachine stateMachine,  string animBoolName, Enemy_Skeleton enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.fx.InvokeRepeating("RedColoBlink", 0, .1f);

        stateTimer=enemy.stunDuration;

        rb.velocity=new Vector2(-enemy.facingDir*enemy.stunDirection.x, enemy.stunDirection.y); 
    }

    public override void Exit()
    {
        base.Exit();

        enemy.fx.Invoke("CancelRedBlink", 0);
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            stateMachine.ChangeState(enemy.idleState);
    }
}
