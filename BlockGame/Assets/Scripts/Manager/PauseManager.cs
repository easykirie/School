using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

	public void GameQuit()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
