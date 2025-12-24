using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCamera : MonoBehaviour
{
    private Player player;
    private bool fliped;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(player.facingDir==-1&&!fliped)
        {
            transform.Rotate(0, 180, 0);
            fliped = true;
        }
        if(player.facingDir==1 && !fliped)
        {
            transform.Rotate(0, 0, 0);
            fliped = true;
        }*/


    }
}