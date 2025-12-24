using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;




public class Entity : MonoBehaviour
{

    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public EntityFX fx { get; private set; }
    public CharacterStat stats  { get; private set; }
    public CapsuleCollider2D cd { get; private set; }
    

    [Header("KnockBack info")]
    [SerializeField] protected Vector2 knockbackDirection;
    [SerializeField] protected float knockbackDuration;
    protected bool isKnocked;

    [Header("Coliision info")]
    public Transform attackCheck;
    public float attackCheckRadius;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform groundEageCheck;
    [SerializeField] protected float groundEageCheckDistance;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected Transform wall2RotateCheck;
    [SerializeField] protected float wall2RotateCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;
    [SerializeField] protected LayerMask whatIsWall2Rotate;

    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;

    public System.Action onFlipped;

    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {
        fx = GetComponent<EntityFX>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stats=GetComponent<CharacterStat>();
        cd = GetComponent<CapsuleCollider2D>();
        

    }
    protected virtual void Update()
    {

    }

    public virtual void DamageEffect()
    {
        fx.StartCoroutine("FlashFX");
        StartCoroutine("HitKnockback");
    }

    protected virtual IEnumerator HitKnockback()
    {
        isKnocked=true;

        rb.velocity = new Vector2(knockbackDirection.x * -facingDir, knockbackDirection.y);
        
        yield return new WaitForSeconds(knockbackDuration);
        
        isKnocked = false;
    }

    #region Velocity
    public void SetZeroVelocity()
    {
        if(isKnocked)
            return;

         rb.velocity = new Vector2(0, 0);
    }
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        if (isKnocked)
            return;

        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }
    #endregion

    #region Collision
    public bool IsGroundDetecteed() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public bool IsGroundEageDetecteed() => Physics2D.Raycast(groundEageCheck.position, Vector2.down, groundEageCheckDistance, whatIsGround);
    public bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);
    public bool IsWall2RotateDetected() => Physics2D.Raycast(wall2RotateCheck.position, Vector2.right * facingDir, wall2RotateCheckDistance, whatIsWall2Rotate);
    
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(groundEageCheck.position, new Vector3(groundEageCheck.position.x, groundEageCheck.position.y - groundEageCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
        Gizmos.DrawLine(wall2RotateCheck.position, new Vector3(wall2RotateCheck.position.x + wall2RotateCheckDistance, wall2RotateCheck.position.y));
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius); 
    }
    #endregion

    #region Flip
    public void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
        if(onFlipped!=null)
            onFlipped();
    }
    public void FlipController(float _x)
    {
        if (_x < 0 && facingRight)
            Flip();
        else if (_x > 0 && !facingRight)
            Flip();

    }
    #endregion

    public virtual void Die()
    {
        
    }
}
