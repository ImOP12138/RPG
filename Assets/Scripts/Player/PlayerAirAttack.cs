using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirAttack : PlayerState
{
    private int comboCounter;
    private float lastTimeAttacked;
    private float comboWindow = 1;
    public PlayerAirAttack(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        xInput = 0;

        if (comboCounter > 1 || Time.time >= lastTimeAttacked + comboWindow)
            comboCounter = 0;
        Player.anim.SetInteger("ComboCounter", comboCounter);


        float attackDir = Player.facingDir;
        if (xInput != 0)
            attackDir = xInput;


        
        stateTimer = .25f;
    }

    public override void Exit()
    {
        base.Exit();
        Player.StartCoroutine("BusyFor", .15f);
        comboCounter++;
        lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
            stateMachine.ChangeState(Player.airState);

        if (triggerCalled)
            stateMachine.ChangeState(Player.airState);
    }
}
