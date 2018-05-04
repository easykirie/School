using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTester : MonoBehaviour {

    public Character character;
    
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            character.Method2();
        }
    }


}
