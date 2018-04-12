using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public PlayerHealth playerHealth;
    public float restartDelay = 5;

    Animator anim;
    float restartTime;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");

            restartTime += Time.deltaTime;

            if(restartTime >= restartDelay)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
	}
}
