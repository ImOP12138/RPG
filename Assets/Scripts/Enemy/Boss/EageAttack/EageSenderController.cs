using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EageSenderController : MonoBehaviour
{
    public EageSender1 attack1; // 第一个攻击脚本
    public EageSender2 attack2; // 第二个攻击脚本
    public EageSender3 attack3; // 第三个攻击脚本
    public EageSender4 attack4;
    public float switchInterval = 5f; // 切换间隔

    private Coroutine switchCoroutine;
    private void Start()
    {
        // 启动切换协程
        switchCoroutine = StartCoroutine(SwitchAttacks());
    }

    private IEnumerator SwitchAttacks()
    {
        while (true)
        {
            // 切换到第一个攻击脚本
            if (attack1 != null)
                attack1.enabled = true;

            if (attack2 != null)
                attack2.enabled = false;

            if (attack3 != null)
                attack3.enabled = false;

            if (attack4 != null)
                attack4.enabled = false;

            yield return new WaitForSeconds(switchInterval);

            if (attack1 != null)
                attack1.enabled = false;

            if (attack2 != null)
                attack2.enabled = false;

            if (attack3 != null)
                attack3.enabled = false;

            if (attack4 != null)
                attack4.enabled = false;

            yield return new WaitForSeconds(2f); // 停止攻击2秒

            if (attack1 != null)
                attack1.enabled = false;

            if (attack2 != null)
                attack2.enabled = true;

            if (attack3 != null)
                attack3.enabled = false;

            if (attack4 != null)
                attack4.enabled = false;

            yield return new WaitForSeconds(switchInterval);

            if (attack1 != null)
                attack1.enabled = false;

            if (attack2 != null)
                attack2.enabled = false;

            if (attack3 != null)
                attack3.enabled = true;

            if (attack4 != null)
                attack4.enabled = false;

            yield return new WaitForSeconds(switchInterval);

            if (attack1 != null)
                attack1.enabled = false;

            if (attack2 != null)
                attack2.enabled = false;

            if (attack3 != null)
                attack3.enabled = false;

            if (attack4 != null)
                attack4.enabled = true;

            yield return new WaitForSeconds(switchInterval);
        }
    }
}
