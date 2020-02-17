using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public static class XMLSaving
{
    public static HighScores ReadData()
    {
        //New string path that is the applications data path with /Highscore.sav
        string path = Application.persistentDataPath + "/HighScore.XML";
        //If the file path exists
        if (File.Exists(path))
        {
            //New XML serializer for highsocores data
            var serializer = new XmlSerializer(typeof(HighScores));
            //New file stream to open file at path location
            var stream = new FileStream(path, FileMode.Open);
            //New container for the data to deserialize as highscores
            var container = serializer.Deserialize(stream) as HighScores;
            //Close the stream
            stream.Close();
            //Return the container
            return container;
        }
        else
        {
            //Return null
            return null;
        }
    }

    public static void WriteData(HighScores data)
    {
        //New XML serializer for highsocores data
        var serializer = new XmlSerializer(typeof(HighScores));
        //New string path that is the applications data path with /Highscore.sav
        string path = Application.persistentDataPath + "/HighScore.XML";
        //New file stream at path location
        var stream = new FileStream(path, FileMode.Create);
        //serialze the data
        serializer.Serialize(stream, data);
        //Close Stream
        stream.Close();
    }
}
