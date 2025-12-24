using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float LinerVelocity = 0;
    public float Acceleration = 0;
    public float AngularVelocity = 0;
    public float AngularAcceleration = 0;
    public float MaxVelocity=int.MaxValue;
    public float LifeTime = 5f;
    private bool WallTouched;
    private bool PlayerTouched;
    Player player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void FixedUpdate()
    {
        //更新线速度与角速度
        LinerVelocity = Mathf.Clamp(LinerVelocity+Acceleration*Time.fixedDeltaTime,-MaxVelocity,MaxVelocity);
        AngularVelocity+=AngularAcceleration*Time.fixedDeltaTime;
        //更新子弹位置
        transform.Translate(LinerVelocity * Vector2.right * Time.fixedDeltaTime,Space.Self);
        transform.rotation*=Quaternion.Euler(new Vector3(0,0,1)*AngularVelocity*Time.fixedDeltaTime);
        LifeTime-=Time.fixedDeltaTime;
        if (LifeTime < 0||WallTouched||PlayerTouched)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            player.stats.TakeDamage(1);
            PlayerTouched=true;
        }
        if (collision.CompareTag("item"))
            WallTouched = true;
    }


}
