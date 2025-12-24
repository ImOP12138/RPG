using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash2SkyState : PlayerState
{
    public PlayerDash2SkyState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
    }

    public override void Exit()
    {
        base.Exit();
        //Player.SetVelocity(rb.velocity.x, rb.velocity.y);
    }

    public override void Update()
    {
        base.Update();
        Dash2Sky();
    }
    private void Dash2Sky()
    {

        if (!Player.IsGroundDetecteed() && Player.IsWallDetected())
            stateMachine.ChangeState(Player.wallSlideState);

        Player.SetVelocity(0, Player.dashSpeed2Sky);

        if (Player.IsSkyDetecteed())//Åöµ½Ìì»¨°å
        {
            Player.SetVelocity(5* Player.dashDir, rb.velocity.y);
            stateMachine.ChangeState(Player.jumpState);
        }

        //Player.rb.gravityScale = 0;


    }
}
