using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{

    public GameObject block;

    public bool CanBreak;

    int block_num;

    public GameObject[] items;

    int item_num;
    int CanDrop;

    void ItemNumCheck()
    {
        if (items[0].tag == "H_Item")
            item_num = 0;
        else if (items[1].tag == "D_Item")
            item_num = 1;
    }

    void BlockNumCheck()
    {
        if (block.tag == "Block")
            block_num = 0;
        else if (block.tag == "BlockW")
            block_num = 1;
        else if (block.tag == "BlockS")
            block_num = 2;
        else if (block.tag == "BlockT")
            block_num = 3;
    }

    private void Awake()
    {
        CanBreak = false;
        BlockNumCheck();
        ItemNumCheck();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ball" && block_num == 0)
        {
            ScoreManager.score += 10;
            Destroy(block);
        }
        else if (col.gameObject.tag == "Ball" && block_num == 1)
        {
            if (CanBreak == false)
                CanBreak = true;
            else if (CanBreak == true)
            {
                ScoreManager.score += 20;
                Destroy(block);
            }
        }
        else if(col.gameObject.tag == "Ball" && block_num == 2)
        {
            ScoreManager.score += 1;
            CanBreak = false;
        }
        else if(col.gameObject.tag == "Ball" && block_num == 3)
        {
            CanDrop = Random.Range(0, items.Length + 3);
            if(CanDrop <= items.Length)
            {
                item_num = Random.Range(0, items.Length);
                Instantiate(items[item_num], block.transform.position, items[item_num].transform.rotation);
                Destroy(block);
            }
            else if(CanDrop == items.Length + 3)
            {
                if (PlayerMove.speed <= 2)
                    PlayerMove.speed = 2;
                PlayerMove.speed -= 1;
            }
            else Destroy(block);
        }

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
    

    