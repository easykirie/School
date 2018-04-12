using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour {

    int[] answer = new int[3];

    public Text[] AnswerTextArray;

	// Use this for initialization
	void Start () {

        int index = 0;
        while(index < 3)
        {
            answer[index] = Random.Range(0, 9);

            bool hasDuplicate = false;

            for(int i=0; i < index; i++)
            {
                if(answer[index] == answer[i])
                {
                    hasDuplicate = true;
                    break;
                }
            }
            if(!hasDuplicate)
            {
                index++;
            }
        }


	}
	
	public Result CompareToAnswer(int[] guess)
    {
        Result result = new Result();

        result.Guess = guess;

        for(int i=0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                if(answer[i] == guess[j])
                {
                    if(i == j)
                    {
                        result.Strike++;
                    }
                    else
                    {
                        result.Ball++;
                    }
                }
            }
        }

        result.Out = 3 - result.Strike - result.Ball;

        if(result.Strike == 3)
        {
            AnswerTextArray[0].text = answer[0].ToString();
            AnswerTextArray[0].text = answer[1].ToString();
            AnswerTextArray[0].text = answer[2].ToString();
        }

        return result;
    }
}
