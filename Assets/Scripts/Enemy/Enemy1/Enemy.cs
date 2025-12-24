using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] protected LayerMask whatIsPlayer;

    [Header("Stuned info")]
    public float stunDuration;
    public Vector2 stunDirection;
    protected bool canBeStunned;
    [SerializeField] protected GameObject counterImage;

    [Header("Move info")]
    public float moveSpeed;
    public float idleTime;
    public float battleTime;

    [Header("Attack info")]
    public float attackDistance;
    public float attackCooldown;
    [SerializeField] protected Transform playerCheck;
    public float playerDetectedDistance;
    [HideInInspector] public float lastTimeAttacked;


    public EnemyStateMachine stateMachine { get; private set; }
    public string lastAnimBoolName { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
    }
    protected override void Update()
    {
        base.Update();

        stateMachine.currentState.Update();
    }

    public virtual void AssignLastAnimName(string _animBoolName)
    {
        lastAnimBoolName=_animBoolName;
    }

    public virtual void OpenCounterAttackWindow()
    {
        canBeStunned = true;
        counterImage.SetActive(true);
    }
    public virtual void CloseCounterAttackWindow()
    {
        canBeStunned = false;
        counterImage.SetActive(false);
    }

    protected virtual bool CanBeStunned()
    {
        if(canBeStunned)
        {
            CloseCounterAttackWindow();
            return true;
        }
        return false;
    }


    public virtual void AnimationFinishTrigger()=>stateMachine.currentState.AnimationFinishTrigger();

    public virtual RaycastHit2D IsPlayerDetected()=>Physics2D.Raycast(wallCheck.position, Vector2.right*facingDir, playerDetectedDistance, whatIsPlayer);
    
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color=Color.yellow;
        Gizmos.DrawLine(transform.position,new Vector3(transform.position.x +attackDistance*facingDir,transform.position.y));
        Gizmos.DrawLine(playerCheck.position,new Vector3(playerCheck.position.x + playerDetectedDistance * facingDir,playerCheck.position.y));
        
    }

}
