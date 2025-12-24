using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenderController : MonoBehaviour
{
    public Sender attack1; // 第一个攻击脚本
    public Sender2 attack2; // 第二个攻击脚本
    public Sender3 attack3; // 第三个攻击脚本
    public Sender4 attack4;
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
            attack1.enabled = false;
            attack2.enabled = false;
            attack3.enabled = false;
            attack4.enabled = false;

            yield return new WaitForSeconds(switchInterval);
            attack1.enabled = false;
            attack2.enabled = false;
            attack3.enabled = false;
            attack4.enabled = false;
            yield return new WaitForSeconds(2f);//停止攻击2秒
            attack1.enabled = false;
            attack2.enabled = false;
            attack3.enabled = false;
            attack4.enabled = false;

            yield return new WaitForSeconds(switchInterval);
            attack1.enabled = false;
            attack2.enabled = false;
            attack3.enabled = false;
            attack4.enabled = false;
            yield return new WaitForSeconds(2f);//停止攻击2秒
            attack1.enabled = false;
            attack2.enabled = false;
            attack3.enabled = true;
            attack4.enabled = false;

            yield return new WaitForSeconds(switchInterval);
            attack1.enabled = false;
            attack2.enabled = false;
            attack3.enabled = false;
            attack4.enabled = true;

            yield return new WaitForSeconds(switchInterval);
        }
    }
}
