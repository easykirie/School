using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    public GameObject pause;

    public static bool IsOver;

    public void Awake()
    {
        IsOver = false;
    }

    public void GameQuit()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    void TimeStop()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 0 && IsOver == false)
            {
                Time.timeScale = 1;
                pause.gameObject.SetActive(false);
            }
            else if (Time.timeScale != 0 && IsOver == false)
            {                
                Time.timeScale = 0;
                pause.gameObject.SetActive(true);
            }
            
        }
    }

    

    private void Update()
    {
        if (pause.gameObject.activeInHierarchy == false)
        {
            Time.timeScale = 1;
        }
        TimeStop();
    }
}
