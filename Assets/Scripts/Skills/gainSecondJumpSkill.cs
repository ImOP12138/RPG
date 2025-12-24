using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gainSecondJumpSkill : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (other.transform.position.y > transform.position.y)
                return;
            other.gameObject.GetComponent<Player>().canJumpTwice=true;
            Destroy(gameObject);
        }
        
    }
}
