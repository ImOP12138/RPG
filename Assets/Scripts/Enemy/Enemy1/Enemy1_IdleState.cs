using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Enemy1_IdleState : EnemyGroundedState
{
    public Enemy1_IdleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Enemy_Skeleton enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetZeroVelocity();
        stateTimer = enemy.idleTime;
    }


    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            stateMachine.ChangeState(enemy.moveState);

        
    }
    public override void Exit()
    {
        base.Exit();
    }
}
