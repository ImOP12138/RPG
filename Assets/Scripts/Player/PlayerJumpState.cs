using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    int jumpMaxCount = 1;
    
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.jumpCount = jumpMaxCount;
        rb.velocity = new Vector2(rb.velocity.x, Player.junpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        Jump();

        Move();
        if (Input.GetKeyDown(KeyCode.Mouse0))
            stateMachine.ChangeState(Player.airAttack);
    }

    private void Jump()
    {
        if (Player.IsGroundDetecteed() && Player.jumpCount != jumpMaxCount)
            Player.jumpCount = jumpMaxCount;//ÖØÖÃ´ÎÊý

        if( Player.canJumpTwice)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Player.jumpCount > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, Player.junpForce);
                Player.jumpCount--;
            }

        }
        if (rb.velocity.y < 0)
        {
            stateMachine.ChangeState(Player.airState);
           
        }
            
    }

    private void Move()
    {
        Player.SetVelocity(xInput * Player.moveSpeed, rb.velocity.y);
    }
}
