using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ScoreHandler : MonoBehaviour
{
    public Scores[] high = new Scores[10]; //New Scores high
    public void Awake()
    {
        //Load Data saved
        LoadData();
    }

    public void LoadData()
    {
        //Load the data from the XML File
        HighScores data = XMLSaving.ReadData();
        //If data isnt equal to null
        if (data != null)
        {
            //for all high
            for (int i = 0; i < high.Length; i++)
            {
                //Set the player in high to player playername in data 
                high[i].player = data.playerName[i];
                //set the wave in high to the wave in data
                high[i].dis = data.wave[i];
            }
        }
        else //else if data is null
        {
            //for each high
            for (int i = 0; i < high.Length; i++)
            {
                //Set the player to blank
                high[i].player = "Blank";
                //Set the wave to zero
                high[i].dis = 0;
            }
        }
        //Sort the score data
        Sort();
    }

    //When a new score is added
    public void NewScore(string name, int number)
    {
        //Set the wave 0 to the number
        high[0].dis = number;
        //set the player to equal name
        high[0].player = name;
        //Sort
        Sort();
    }

    public void Sort()
    {
        //Sort the strut in a desending order
        Array.Sort(high, (x, y) => x.dis.CompareTo(y.dis));
        //Save the data
        Save();
    }

    //Save the highscore data
    public void Save()
    {
        //New Highscores class under the refernce data
        HighScores data = new HighScores();
        //New temp string name
        string[] name = new string[10];
        //New temp string number
        int[] number = new int[10];
        //For every strut in the high array
        for (int i = 0; i < high.Length; i++)
        {
            //Set data in playername in location i of the array to high in location i of the struts string player
            data.playerName[i] = high[i].player;
            //Set data in wave in location i of the array to high in location i of the struts int wave
            data.wave[i] = high[i].dis;
        }
        //Write the Variable data to an XML file
        XMLSaving.WriteData(data);
    }
}

[System.Serializable]
public struct Scores
{
    public string player; //String for player names
    public int dis; //int for ammount of waves done
}
