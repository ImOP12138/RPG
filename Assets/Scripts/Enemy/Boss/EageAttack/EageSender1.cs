using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EageSender1 : MonoBehaviour
{
    public BulletObject bullet;
    private Player player;
    GameObject gridObject;
    float currentAngle = 0;
    float currentAngularVelocity = 0;
    float currentTime = 0;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        currentAngle = FindPlayer();
        currentAngularVelocity = bullet.SenderAngularVelocity;
        gridObject = GameObject.Find("Grid");
    }
    private void FixedUpdate()
    {

        currentAngularVelocity = Mathf.Clamp(currentAngularVelocity + bullet.SenderAcceleration * Time.fixedDeltaTime,
            -bullet.SenderMaxAngularVelocity, bullet.SenderMaxAngularVelocity);
        //更新角度
        currentAngle += currentAngularVelocity * Time.fixedDeltaTime;
        //限制角度
        if (Mathf.Abs(currentAngle) > 720f)
        {
            currentAngle -= Mathf.Sign(currentAngle) * 360f;
        }

        //更新时间
        currentTime += Time.fixedDeltaTime;
        if (currentTime > bullet.SendInterval)
        {
            currentTime -= bullet.SendInterval;
            SendByCount(bullet.count, currentAngle);
        }
    }
    private void SendByCount(int count, float angle)
    {
        float temp = count % 2 == 0 ? angle + bullet.LinerAngle / 2 : angle;
        for (int i = 0; i < count; ++i)
        {
            temp += Mathf.Pow(-1, i) * i * bullet.LinerAngle;
            Send(temp);
        }
    }
    private void Send(float angle)
    {

        //生成子弹
        GameObject go = Instantiate(bullet.prefabs);
        go.transform.SetParent(gridObject.transform);
        go.transform.position = transform.position;
        //设置子弹初始旋转
        go.transform.rotation = Quaternion.Euler(0, 0, angle);
        var bh = go.AddComponent<BulletBehavior>();
        //初始化子弹的配置信息
        InitBullet(bh);
    }
    private void InitBullet(BulletBehavior bh)
    {
        bh.LinerVelocity = bullet.LinerVelocity;
        bh.Acceleration = bullet.Acceleration;
        bh.AngularVelocity = bullet.AngularVelocity;
        bh.AngularAcceleration = bullet.AngularAcceleration;
        bh.LifeTime = bullet.LifeCycle;
        bh.MaxVelocity = bullet.MaxVelocity;
    }
    private float FindPlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float angle360 = Mathf.Repeat(angle, 360f);

        return angle360;
    }

}
