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
    public int H_count;

    public void BoxCheck()
    {
        if (box.transform.CompareTag("Low"))
            box_index = 0;
        else if (box.transform.CompareTag("Middle"))
            box_index = 1;
        else if (box.transform.CompareTag("Top"))
            box_index = 2;
    }

    public void Awake()
    {
        BoxCheck();
         Get(0);
    }

    public Dialoge Get(int id)
    {
        //
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
            //for (i = 0; i <= coinCount; i++)
            //    Instantiate(coin, box.transform.position, Quaternion.identity);
        }
        else if (box_index == 2)
        {
            coinPrefab = S_coin;
            coinCount = Random.Range(15, 25);
            //for(i=0;i<=coinCount;i++)
            //    Instantiate(S_coin, box.transform.position, Quaternion.identity);
        }

        for (i = 0; i <= coinCount; i++)
            Instantiate(coinPrefab, box.transform.position, Quaternion.identity);
        if (H_range == 1)
            for (i = 0; i <= H_count; i++)
                Instantiate(H_potion, box.transform.position, Quaternion.identity);
    }

}
