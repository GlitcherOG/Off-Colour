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
        Invoke("LoadScore", 0.1f);
    }
    private void Update()
    {
        score.text = distance.ToString();
        if (distance >= highscore)
        {
            highscore = distance;
        }
        highscoreText.text = highscore.ToString();
    }

    public void LoadScore()
    {
        highscore = handle.high[handle.high.Length - 1].dis;
    }

    public void save()
    {
        handle.NewScore("Player", (int)distance);
    }

}
