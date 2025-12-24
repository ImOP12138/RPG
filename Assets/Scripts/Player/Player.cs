using System.Collections;
using System.Collections.Generic;


using UnityEngine;

public class Player : Entity
{
    Vector2 checkPointPos;
    Collider2D coll;
    
    

    [Header("Attack details")]
    public Vector2[] attackMovement;
   

    public bool isBusy { get; private set; }
    [Header("Move info")]
    public float moveSpeed = 12f;
    public float junpForce;
    public int jumpCount=1;
    public bool canJumpTwice;

    [Header("Dash info")]
    public float dashSpeed;
    public float dashSpeed2Sky;
    public float dashDuration;
    public float dashDir { get; private set; }
    public bool canDash;
    public bool canDash2Sky;
    [Header("Special Area")]
    [SerializeField] protected Transform AreaCheck;
    [SerializeField] protected float AreaCheckDistance;
    [SerializeField] protected Transform SkyCheck;
    [SerializeField] protected float SkyCheckDistance;
    [SerializeField] protected LayerMask whatAreaIs;
    [SerializeField] protected LayerMask whatSkyIs;



    public SkillManager skill { get; private set; }
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PLayerMoveState moveState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerWallJump wallJump { get; private set; }
    public PlayerPrimaryAttackState primaryAttack { get; private set; }
    public PlayerDeadState deadState { get; private set; }
    public PlayerAirAttack airAttack { get; private set; }
    public PlayerDash2SkyState dash2SkyState { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        stateMachine=new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PLayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState  = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallSlideState = new PlayerWallSlideState(this, stateMachine, "WallSlide");
        wallJump = new PlayerWallJump(this, stateMachine, "Jump");
        primaryAttack = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
        deadState = new PlayerDeadState(this, stateMachine, "Die");
        airAttack = new PlayerAirAttack(this, stateMachine, "AirAttack");
        dash2SkyState = new PlayerDash2SkyState(this, stateMachine, "TouchSky");

        coll = GetComponent<Collider2D>();
       
        
    }
    protected override void Start()
    {
        base.Start();

        checkPointPos = transform.position;
        skill = SkillManager.instance;
        stateMachine.Initialize(idleState);
        
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
        CheckForDashInput();
        



    }

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy=true;
        yield return new WaitForSeconds(_seconds);
        isBusy = false;
    }

    public void AnimationTrigger()=>stateMachine.currentState.AnimationFinishTrigger();

    

    private bool isDie;
    public override void Die()
    {
        if (isDie) return;
        base.Die();
        stateMachine.ChangeState(deadState);
        
        //stats.TakeDamage(stats.currentHealth);//将生命值UI置为空
        StartCoroutine(Respawn(1f));//复活
    }
    public bool IsAreaDetecteed() => Physics2D.Raycast(AreaCheck.position, Vector2.up, AreaCheckDistance, whatAreaIs);
    public bool IsSkyDetecteed() => Physics2D.Raycast(SkyCheck.position, Vector2.up, SkyCheckDistance, whatSkyIs);


    public void UpdateCheckPoint(Vector2 pos)
    {
        checkPointPos = pos;
    }
    IEnumerator Respawn(float duaration)
    {
        isDie = true;
        yield return new WaitForSeconds(duaration);
        stats.currentHealth=stats.GetMaxHealthValue();//重置血量
        stats.onHealthChanged?.Invoke();
       
        transform.position=checkPointPos;
        stateMachine.ChangeState(idleState);
        isDie = false;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CheckPoint"))
        {
            collision.enabled = false;
        }
    }
    
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawLine(SkyCheck.position, new Vector3(SkyCheck.position.x, SkyCheck.position.y - SkyCheckDistance));
    }
    public void CheckForDashInput()
    {
        if (IsWallDetected())
            return;

        if (Input.GetKeyUp(KeyCode.LeftControl) && SkillManager.instance.dash.CanUseSkill())
        {

            dashDir = Input.GetAxisRaw("Horizontal");

            if (dashDir == 0)
                dashDir = facingDir;

            if (canDash)
                stateMachine.ChangeState(dashState);
        }

    }
    

}
