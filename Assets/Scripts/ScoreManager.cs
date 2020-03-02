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
    public ScoreHandler handle;

    private void Start()
    {
        if (highscore == 0)
        {
            highscore = handle.high[1].dis;
        }
    }
    private void Update()
    {
        score.text = distance.ToString();
        if (distance >= highscore)
        {
            highscoreText.text = distance.ToString();
        }
        else
        {
            highscoreText.text = handle.high[9].ToString();
        }
    }

    public void save()
    {
        handle.NewScore("Player", (int)distance);
    }

}
