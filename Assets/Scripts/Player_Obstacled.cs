using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Obstacled : MonoBehaviour
{

    Player player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.stats.TakeDamage(1000);
        }
    }
}
