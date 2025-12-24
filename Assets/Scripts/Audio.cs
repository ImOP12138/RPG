using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private static bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        if(isPlaying)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        GetComponent<AudioSource>().Play();
        isPlaying = true;
    }

    
}
