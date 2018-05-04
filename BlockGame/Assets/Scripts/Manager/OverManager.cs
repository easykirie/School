using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverManager : MonoBehaviour {

    public GameObject Over;

    

    public static bool IsEnd;

    

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
        if(BallController.reviveCount <= 0 && IsEnd == true)
        {
            Time.timeScale = 0;
            Over.gameObject.SetActive(true);
        }

	}

    public void GameReTry()
    {
        if (MenuManager.easy == true)
            SceneManager.LoadScene("MainScene_Easy");
        else if (MenuManager.normal == true)
            SceneManager.LoadScene("MainScene_Normal");
        else if (MenuManager.hard == true)
            SceneManager.LoadScene("MainScene_Hard");

    }

    public void GameQuit()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
