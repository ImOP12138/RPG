using System.Collections;
using UnityEngine;

public class SmartBat : Entity
{
    public float speed;
    public float dashSpeed;
    public float radius;
    public float attackRadius;
    public Animator anim { get; private set; }
    private Transform playerTransform;
    private Player player;
    private Rigidbody2D rb;
    private Coroutine stateCoroutine;
    private bool isAttacking;

    public void Start()
    {
        anim = GetComponentInChildren<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();

        // 启动状态机协程
        stateCoroutine = StartCoroutine(StateMachine());
    }

    private IEnumerator StateMachine()
    {
        while (true)
        {
            if (!isAttacking)
            {
                PlayerCheck();
            }

            yield return null;
        }
    }

    private void PlayerCheck()
    {
        if (playerTransform != null)
        {
            float distance = (transform.position - playerTransform.position).magnitude;
            if (distance < radius && distance >= attackRadius)
            {
                // 追踪玩家
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            }
            else if (distance < attackRadius)
            {
                // 切换到攻击状态
                isAttacking = true;
                StartCoroutine(AttackPlayer());
            }
            else
            {
                //正常来回寻路
                //StartCoroutine(FlyNormally());
                
            }
        }
    }
    private IEnumerator FlyNormally()
    {
        rb.velocity = new Vector2(speed * facingDir, rb.velocity.y);

        if (IsWallDetected() || !IsGroundDetecteed())
        {
            print(IsWallDetected());
            print(!IsGroundDetecteed());
            Flip();
            IdleForSeconds();
        }
        yield return null ;
    }
    private IEnumerator IdleForSeconds()
    {
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(1f); 
    }

    private IEnumerator AttackPlayer()
    {
        
        // 计算怪物到玩家的方向向量
        Vector2 direction = (playerTransform.position - transform.position).normalized;

        
        // 施加冲刺的速度
        rb.velocity = new Vector2(direction.x, direction.y) * dashSpeed;

        // 等待一段时间
        yield return new WaitForSeconds(1.5f);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(1.5f);

        // 结束攻击状态
        isAttacking = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.stats.TakeDamage(5);
        }
    }
    public override void Die()
    {
        base.Die();
        
        Destroy(gameObject);
        
    }

}