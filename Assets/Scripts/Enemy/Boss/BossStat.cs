using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossStats : CharacterStat
{
    private GameObject BOSS;
    public BossEntity boss;
    public GameObject Button;
    public EntityFX fx { get; private set; }
    Transform childSender1;
    BossEntity eageSender1;
    Transform childSender2;
    BossEntity eageSender2;
    Transform childSender3;
    BossEntity eageSender3;
    Transform childSender4;
    BossEntity eageSender4;

    protected override void Start()
    {
        base.Start();
        BOSS = GameObject.Find("Boss");
        fx = GetComponent<EntityFX>();
        boss = GetComponent<BossEntity>();
        childSender1 = transform.Find("EageSender1");
        eageSender1 = childSender1.GetComponent<BossEntity>();
        childSender2 = transform.Find("EageSender2");
        eageSender2 = childSender2.GetComponent<BossEntity>();
        childSender3 = transform.Find("EageSender3");
        eageSender3 = childSender3.GetComponent<BossEntity>();
        childSender4 = transform.Find("EageSender4");
        eageSender4 = childSender4.GetComponent<BossEntity>();
    }
    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);

        if (fx != null)
            fx.StartCoroutine("FlashFX");

        if (currentHealth <= GetMaxHealthValue() * 0.75 && !eageSender1.IsUnityNull())
            eageSender1?.Die();

        if (currentHealth <= GetMaxHealthValue() * 0.5 && !eageSender2.IsUnityNull())
            eageSender2?.Die();

        if (currentHealth <= GetMaxHealthValue() * 0.25 && !eageSender3.IsUnityNull())
            eageSender3?.Die();
        if (currentHealth <= GetMaxHealthValue() * 0 && !eageSender4.IsUnityNull())
        {

            Destroy(BOSS);
            Button.SetActive(true);
        }
    }
    
}
