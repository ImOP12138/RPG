using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.jumpCount = 1;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(Player.wallJump);
            return;
        }

        if (xInput != 0 && Player.facingDir != xInput)
            stateMachine.ChangeState(Player.idleState);

        if(yInput<0)
            rb.velocity = new Vector2(0, rb.velocity.y);
        else
            rb.velocity = new Vector2(0, rb.velocity.y * .7f);

        if(Player.IsGroundDetecteed())
            stateMachine.ChangeState(Player.idleState);
        if (!Player.IsWallDetected())
            stateMachine.ChangeState(Player.airState);
    }
}
