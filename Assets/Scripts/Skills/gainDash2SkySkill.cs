using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gainDash2SkySkill : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.transform.position.y > transform.position.y)
                return;
            other.gameObject.GetComponent<Player>().canDash2Sky = true;
            Destroy(gameObject);
        }

    }
}
