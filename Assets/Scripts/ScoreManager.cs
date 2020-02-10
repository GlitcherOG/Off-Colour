using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static float distance;
    public Text score;
    private void Update()
    {
        score.text = distance.ToString();
    }
}
