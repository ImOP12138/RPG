using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundedState : EnemyState
{
    protected Enemy_Skeleton enemy;
    protected Transform player;
    public EnemyGroundedState( Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName ,Enemy_Skeleton enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = PlayerManager.instance.player.transform;
    }


    public override void Update()
    {
        base.Update();

        if (enemy.IsPlayerDetected()||Vector2.Distance(player.transform.position,enemy.transform.position)<2)
            stateMachine.Initialize(enemy.battleState);
    }
    public override void Exit()
    {
        base.Exit();
    }
}
