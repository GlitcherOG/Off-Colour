using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static float distance;
    public float highscore;
    public Text score;
    public Text highscoreText;
    private void Update()
    {
        score.text = distance.ToString();
        if(distance >= highscore)
        {
            highscoreText.text = distance.ToString();
        }
    }
}
