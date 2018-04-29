using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public static bool easy = false;
    public static bool normal = false;
    public static bool hard = false;

    public void Start()
    {
        easy = true;
    }

    public void PlayGame()
    {
        if(easy == true)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if(normal == true)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        if(hard == true)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void Easy()
    {
        easy = true;
    }

    public void Normal()
    {
        normal = true;
    }

    public void Hard()
    {
        hard = true;
    }
}
