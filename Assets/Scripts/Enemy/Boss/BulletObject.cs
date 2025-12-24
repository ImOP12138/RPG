using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create BulletAsset")]
public class BulletObject : ScriptableObject
{
    
    [Header("子弹初始配置")]
    public float LifeCycle = 5;
    public float LinerVelocity = 0;
    public float Acceleration = 0;
    public float AngularVelocity = 0;
    public float AngularAcceleration = 0;
    public float MaxVelocity = int.MaxValue;
    [Header("发射器初始配置")]
    public float InitRotation = 0;
    public float SenderAngularVelocity = 0;
    public float SenderMaxAngularVelocity=int.MaxValue;
    public float SenderAcceleration = 0;
    public int count = 0;
    public float LinerAngle = 30;
    public float SendInterval = 0.1f;
    [Header("预制体")]
    public GameObject prefabs;



}
