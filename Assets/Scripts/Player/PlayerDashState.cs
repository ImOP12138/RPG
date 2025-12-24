using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDashState : PlayerState
{

    CapsuleCollider2D collider;
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        collider = Player.GetComponent<CapsuleCollider2D>();

        //Player.skill.clone.CreateClone(Player.transform);

        stateTimer = Player.dashDuration;
        collider.enabled = false;

        
    }

    public override void Exit()
    {
        base.Exit();
        Player.SetVelocity(0, rb.velocity.y);
        collider.enabled = true;
    }

    public override void Update()
    {
        base.Update();
        
        Dash();
        
    }

    private void Dash()
    {
        
            if (!Player.IsGroundDetecteed() && Player.IsWallDetected())
        {
            collider.enabled = true;
            stateMachine.ChangeState(Player.wallSlideState);
        }

            Player.SetVelocity(Player.dashSpeed * Player.dashDir, 0);

        if (xInput != 0)
        {
            //Player.SetVelocity(Player.moveSpeed * .8f * xInput, rb.velocity.y);
            stateMachine.ChangeState(Player.airState);
        }
        if(Input.GetKeyDown(KeyCode.Space))
            stateMachine.ChangeState(Player.jumpState);

        if (stateTimer < 0)
        {
            collider.enabled = true;
            stateMachine.ChangeState(Player.idleState);
        }
        
        
        

    }
}
