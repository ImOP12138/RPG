using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerMoveState : PlayerGroundedState
{ 
    public PLayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        Move();
    }

    private void Move()
    {
        Player.SetVelocity(xInput * Player.moveSpeed, rb.velocity.y);

        if (xInput == 0 || Player.IsWallDetected())
            stateMachine.ChangeState(Player.idleState);
    }
}
