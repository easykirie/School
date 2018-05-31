using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//함정 발동 때 문 전체의 필드를 구분해서 해당 지역 문 활성화
//보스룸 입성 때도 활성화
public class TrapDoor : MonoBehaviour {


    public List<Transform> TDs;
    public List<Transform> TD_fields;
    public int TDF_num;
    public Animator TDanim;

    

    void Awake()
    {
        TDanim = gameObject.GetComponent<Animator>();
    }
    //TDanim.SetTrigger("Open"); 이건 문열기 요청을 이벤트매니저 통해서 받을때 실행하는 곳에 넣음될듯
    public void Checkfield()
    {
        int TDFs_num = TD_fields.Count;
        for(int i=0;i<=TDFs_num;i++)
        {
            if(TD_fields[i] == TD_fields[TDF_num])//필드쪽 숫자를 지금 충돌난 지역번호로 지정하는걸로 수정해야함.
            {
                TDanim.SetTrigger("Close");
                //해당지역 함정 발동크?
                break;
            }
        }
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
