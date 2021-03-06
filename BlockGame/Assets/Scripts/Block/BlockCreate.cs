﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreate : MonoBehaviour {

    public int MaximumCount;
    public int MinimumCount;
    public Transform[] SpawnPosition;
    public GameObject[] Block;

    int BlockSlength;
    int BlockTlength;
    List<int> BlockPosition = new List<int>();
    int CreateIndex = 0;

    int Block_Create;

    public Transform B_Points;

    

    

    // Use this for initialization
    void Start () {
        MaximumCount = 4 * SpawnPosition.Length / 5;
        MinimumCount = MaximumCount - 2 * MaximumCount / 5;

        

        int count = Random.Range(MinimumCount, MaximumCount);

        while(CreateIndex <= count)
        {
            Block_Create = Random.Range(0, Block.Length);
            int SpawnIndex = Random.Range(0, SpawnPosition.Length);
            bool CanCreate = true;

            for(int i = 0; i < BlockPosition.Count; i++)
            {
                if (BlockPosition[i] == SpawnIndex)
                {
                    CanCreate = false;
                    break;
                }

            }
            if (Block_Create == 4 && BlockSlength == 4)
            {
                CanCreate = false;
                continue;
            }
            else if (Block_Create == 5 && BlockTlength == 4)
            {
                CanCreate = false;
                continue;

            }

            if (CanCreate == true)
            {
                Instantiate(Block[Block_Create], SpawnPosition[SpawnIndex].position, SpawnPosition[SpawnIndex].rotation, B_Points);

                BlockPosition.Add(SpawnIndex);

                CreateIndex++;

                if (Block_Create == 4)
                    BlockSlength += 1;
                else if (Block_Create == 5)
                    BlockTlength += 1;
            }
            
        }
        
	}

    
	
	// Update is called once per frame
	void Update () {
		
	}
}
