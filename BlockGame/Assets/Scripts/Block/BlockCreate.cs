using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreate : MonoBehaviour {

    public int MaximumCount;
    public int MinimumCount;    
    public Transform[] SpawnPosition;
    public GameObject Block;
    List<int> BlockPosition = new List<int>();
    int CreateIndex = 0;

    

    // Use this for initialization
    void Start () {
        MaximumCount = 4 * SpawnPosition.Length / 5;
        MinimumCount = MaximumCount - 3 * MaximumCount / 5;

        int count = Random.Range(MinimumCount, MaximumCount);

        while(CreateIndex <= count)
        {
            int SpawnIndex = Random.Range(0, SpawnPosition.Length);
            bool CanCreate = true;

            for(int i = 0;i < BlockPosition.Count; i++)
            {
                if(BlockPosition[i] == SpawnIndex)
                {
                    CanCreate = false;
                    break;
                }
            }

            if(CanCreate == true)
            {
                Instantiate(Block, SpawnPosition[SpawnIndex].position, SpawnPosition[SpawnIndex].rotation);

                BlockPosition.Add(SpawnIndex);

                CreateIndex++;
            }
            
        }
        
	}

    
	
	// Update is called once per frame
	void Update () {
		
	}
}
