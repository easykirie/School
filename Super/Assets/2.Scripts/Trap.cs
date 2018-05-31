using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {
        
    public Transform player;//본인
    public GameObject[] enemys;//적
    public Transform[] e_spots;//스폰지점
    public int m_num;

    


    void OnTriggerEnter(Collider col)
    {
        if(col.transform.CompareTag("Player"))//플레이어가 범위에 들어갈 때
        {
            int enemy_num = Random.Range(0, enemys.Length);//적 구분
            int e_spotsnum = Random.Range(0, e_spots.Length);//스폰지점 구분
            for(int i=1;i<=m_num;i++)//해당 지역마다 할당된 숫자를 m_num으로 받거나, 이벤트 매니저로 요청보내고 따로 지역마다 할당된 숫자만큼 소환 짜면될듯.
            {
                Instantiate(enemys[enemy_num], e_spots[e_spotsnum].position, Quaternion.identity);//적(랜덤)을 스폰지점(랜덤)에 소환
                //이벤트매니저랑 ㅇㅇ....문들 id로 구분해서 맞는 구역에 있는 애들만 발동(소환도 같게 진행...ㅇ?)
                //보스룸 입장때도 이벤트매니저 호출일듯........아니면 따로 작성
            }
            //몬스터 숫자 세서 0이 되면 문 열기를 이벤트매니저로 보냄..?
        }
    }
    //아마 이걸 함정필드 오브젝트에 넣는다치면 플레이어가 부딪힌 필드 숫자를 얻어서 TrapDoor 스크립트에 넣어주면 구별하는데 사용할 수 있지 않을까 싶음.
    




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
