using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour {

    public float BallSpeed = 1000;
    public Transform SpawnPosition;
    public GameObject Ball;    
    public GameObject Player;
    public bool FirstCheck;
    Rigidbody rigid;
    public Transform tr;//플레이어 위치.
    public Transform b_tr;//공위치.
    GameObject obj;

    public GameObject Blcok;

    
    public bool CanCreate;

    public static int reviveCount;

    

    

    private void Awake()
    {        
        CanCreate = true;        
        BallCreate();        
    }
    // Use this for initialization
    void Start () {
        reviveCount = 2;
    }
	
	// Update is called once per frame
	void Update () {

        BallShoot();

        if(obj == null && reviveCount > 0)
        {
            BallCreate();           
        }
        else if(obj == null && reviveCount <= 0)
        {            
            CanCreate = false;
        }

        
        
        
        
	}

    void BallCreate()
    {
        if(CanCreate == true)
        {
            obj = Instantiate(Ball, SpawnPosition.position, SpawnPosition.rotation);//게임오브젝트 변수 obj에 Ball프리팹을 SpawnPosition 위치랑 각도 저장
            obj.transform.SetParent(SpawnPosition);//변수 obj의 부모로 SpawnPosition을 설정
            rigid = obj.GetComponent<Rigidbody>();
            FirstCheck = false;//FirstCheck를 false로 바꿔서 Space바를 누르면 발사가능하게 해줌.
        }        
    }

    void BallShoot()//FirstCheck가 false고 Space바를 누르면 발사. FirstCheck를 true로 바꿔줌.
    {
        if (FirstCheck == false && Input.GetKeyDown(KeyCode.Space))
        {
            FirstCheck = true;
            obj.transform.SetParent(null);//부모 오브젝트에서 꺼냄(공을) 발사때만.
            rigid.AddForce(Vector3.up * BallSpeed);            
        }
    }

    






}
