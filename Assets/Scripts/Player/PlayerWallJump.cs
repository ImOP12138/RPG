using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJump : PlayerState
{
    public PlayerWallJump(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = .0f;
        Player.SetVelocity(5 * -Player.facingDir, Player.junpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        stateTimer -= Time.deltaTime;
        if (stateTimer < 0)
            stateMachine.ChangeState(Player.airState);
        if(Player.IsGroundDetecteed())
            stateMachine.ChangeState(Player.idleState);
    }
}
