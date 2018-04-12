using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultItem : MonoBehaviour {

    public Text RoundText;

    public Color StrikeColor;
    public Color BallColor;
    public Color OutColor;

    public Image[] ResultIcons;

    public void Setup(int submitCount, Result result)
    {
        RoundText.text = string.Format("{0} Round : {1}, {2}, {3}", submitCount, result.Guess[0], result.Guess[1], result.Guess[2]);

        for(int i = 0; i < 3; i++)
        {
            if(i < result.Strike)
            {
                ResultIcons[i].color = StrikeColor;
            }
            else if(i < result.Strike + result.Ball)
            {
                ResultIcons[i].color = BallColor;
            }
            else
            {
                ResultIcons[i].color = OutColor;
            }
        }
    }

}
