using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    Player player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            
             // 销毁碰撞到的物体
             Destroy(collision.gameObject);
            
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            player.stats.TakeDamage(1000);
        }

    }
    
}