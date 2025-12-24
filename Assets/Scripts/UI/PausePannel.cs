using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePannel : MonoBehaviour
{
    private bool isOpen=false;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {if(!isOpen)
            {
            Open();
            

            }
        else if(isOpen)
        {
            Close();
            
        }
        }
    }

    private void Open()
    {
        Time.timeScale = 0;
        transform.GetChild(0).gameObject.SetActive(true);
        isOpen = true;
    }
    public void Close()
    {
        Time.timeScale = 1;
        transform.GetChild(0).gameObject.SetActive(false);
        isOpen = false;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
