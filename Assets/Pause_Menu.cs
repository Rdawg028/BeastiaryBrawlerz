using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    
    GameObject timer;
    TimerScript isRunning;
    GameObject menu;
    GameObject g;

    private void Start()
    {
        timer = GameObject.Find("Timer");
        isRunning = timer.GetComponent<TimerScript>();
        //g = GameObject.Find("PauseMenu");
        menu = GameObject.FindWithTag("Pause");
        menu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            isRunning.timeRunning = !isRunning.timeRunning;
            menu.SetActive(true);
           // Debug.Log("Pause hit");
           // g.SetActive(true);
            
        }
        
            
               
            
            
    }
    public void Unpause()
    {
        isRunning.timeRunning = !isRunning.timeRunning;
        menu.SetActive(false);
    }


    public void loadmainMenu()
    {
        SceneManager.LoadScene(2);
    }
    
}
