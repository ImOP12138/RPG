using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    
    Player player;
    

    private void Awake()
    {
        player= GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") )
        {
           
            player.UpdateCheckPoint(transform.position);
            
            
        }
        

    }

    
}
