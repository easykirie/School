using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour {


    

    public List<GameObject> skills;
    public int skill_index;
    public GameObject coin;
    public GameObject S_coin;
    public int coinCount;
    public GameObject box;
    public int box_index;
    public GameObject H_potion;
    public int H_count = 2;

    public void BoxCheck()
    {
        if (box.transform.CompareTag("Low"))//함정상자
            box_index = 0;
        else if (box.transform.CompareTag("Middle"))//스테이지 클리어 상자
            box_index = 1;
        else if (box.transform.CompareTag("Top"))//보스 클리어 상자
            box_index = 2;
    }

    public void Awake()
    {
        BoxCheck();
    }


    public void BreakBox()
    {
        int i;
        int H_range = Random.Range(0, 2);

        GameObject coinPrefab = null;

        if (box_index == 0)
        {
            coinCount = Random.Range(5, 10);
            coinPrefab = coin;
        }
        else if (box_index == 1)
        {
            coinPrefab = coin;
            coinCount = Random.Range(11, 15);
        }
        else if (box_index == 2)
        {
            coinPrefab = S_coin;
            coinCount = Random.Range(15, 25);
            skill_index = Random.Range(0, skills.Count);
            Instantiate(skills[skill_index], box.transform.position, Quaternion.identity);
        }

        for (i = 1; i <= coinCount; i++)
            Instantiate(coinPrefab, box.transform.position, Quaternion.identity);
        if (H_range == 1)
            for (i = 1; i <= H_count; i++)
                Instantiate(H_potion, box.transform.position, Quaternion.identity);
    }

}
