using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public float dashDir { get; private set; }
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
            stateMachine.ChangeState(Player.primaryAttack);

        if (!Player.IsGroundDetecteed())
            stateMachine.ChangeState(Player.airState);

        Jump();
        CheckForDash2SkyInput();
    }



    private void Jump()
    {
        
        if (Player.IsGroundDetecteed() && Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(Player.jumpState);           
        }

    }
    public void CheckForDash2SkyInput()
    {


        if (Input.GetKeyUp(KeyCode.Q) && SkillManager.instance.dash.CanUseSkill())
        {

            dashDir = Input.GetAxisRaw("Horizontal");

            if (dashDir == 0)
                dashDir = Player.facingDir;

            if (Player.canDash2Sky)
                stateMachine.ChangeState(Player.dash2SkyState);
        }

    }
}
 

