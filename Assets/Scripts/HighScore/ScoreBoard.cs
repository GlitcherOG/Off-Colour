using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text[] scorePlacements; //Array of text elements
    public ScoreHandler high; //Script ScoreHandler
    void Start()
    {
        //After 0.2 seconds invoke LoadScores
        Invoke("LoadScores", 0.2f);
    }

    public void LoadScores()
    {
        //For every i till i while i is less than 8
        for (int i = 0; i < 8; i++)
        {
            //Change the scoreplacement texts in the location of i in the array
            scorePlacements[i].text = (i+1).ToString() + ". " + high.high[high.high.Length-i-1].player + ": " + high.high[high.high.Length-i-1].dis;
        }
    }
}
