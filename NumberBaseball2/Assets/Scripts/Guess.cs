using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guess : MonoBehaviour {

    public Answer answer;
    public ResultView view;
    public Button submitButton;

    public Text[] guessTextArray;

    public int GuessTextIndex = 0;

    public void SetNumber(int number)
    {
        if(GuessTextIndex < 3)
        {
            guessTextArray[GuessTextIndex].text = number.ToString();
            GuessTextIndex++;
        }
    }

    public void ResetNumber()
    {
        if(GuessTextIndex > 0)
        {
            GuessTextIndex--;
            guessTextArray[GuessTextIndex].text = "0";
            return;
        }        
    }

    public void Submit()
    {
        int[] guessArray = new int[3];

        guessArray[0] = int.Parse(guessTextArray[0].text);
        guessArray[1] = int.Parse(guessTextArray[1].text);
        guessArray[2] = int.Parse(guessTextArray[2].text);

        for(int i=0; i < 3; i++)
        {
            guessTextArray[i].text = "0";
        }

        if(guessArray[0] == guessArray[1] || guessArray[0] == guessArray[2] || guessArray[1] == guessArray[2])
        {
            //경고 출력
            view.DisplayWarning();
            
            return;
        }

        Result result = answer.CompareToAnswer(guessArray);

        if(result.Strike == 3)
        {
            submitButton.interactable = false;
        }

        GuessTextIndex = 0;

        //결과 출력
        view.DisplayResult(result);
    }

}
