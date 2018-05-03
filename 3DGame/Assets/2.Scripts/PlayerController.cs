using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    [SerializeField]
    PlayerJump _playerJump;
    [SerializeField]
    PlayerMovement _playerMovement;
    [SerializeField]
    PlayerSit _playerSit;

    float h;
    float v;

    public KeyCode JumpKey;
    public KeyCode RunKey;
    public KeyCode SitdownKey;

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        _playerMovement.SetDirection(h, v);

        _playerMovement.SetRun(Input.GetKey(RunKey));
    }

    


}
