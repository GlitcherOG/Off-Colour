using System.Xml.Serialization;
[System.Serializable]
public class HighScores
{
    [XmlAttribute("Names")]
    //String array for storing player names
    public string[] playerName = new string[10] {"Blank", "Blank" , "Blank" , "Blank" , "Blank" , "Blank" , "Blank" , "Blank" , "Blank", "Blank" };
    [XmlAttribute("Waves")]
    //String array for storing waves they did
    public int[] wave = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
}
