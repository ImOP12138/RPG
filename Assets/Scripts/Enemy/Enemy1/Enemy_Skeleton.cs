using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy_Skeleton : Enemy
{
    #region States
    public Enemy1_IdleState idleState { get; private set; }
    public Enemy1_MoveState moveState { get; private set; }
    public Enemy1_BattleState battleState { get; private set; }
    public EnemyAttackState attackState { get; private set; }
    public EnemyStunedState stunedState { get; private set; }
    public EnemyDeadState deadState { get; private set; }
    #endregion





    protected override void Awake()
    {
        base.Awake();
        idleState = new Enemy1_IdleState(this, stateMachine, "Idle", this);
        moveState = new Enemy1_MoveState(this, stateMachine, "Move", this);
        battleState = new Enemy1_BattleState(this, stateMachine, "Move", this);
        attackState=new EnemyAttackState(this,stateMachine,"Attack",this);
        stunedState = new EnemyStunedState(this, stateMachine, "Stunned", this);
        deadState = new EnemyDeadState(this, stateMachine, "Idle", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override bool CanBeStunned()
    {
        if(base.CanBeStunned())
        {
            stateMachine.ChangeState(stunedState);
            return true;
        }
        return false;
    }
    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(deadState);
    }
}
