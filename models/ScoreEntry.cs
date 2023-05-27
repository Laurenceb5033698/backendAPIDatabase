using System.Text.Json.Serialization;

namespace DBScoreboard;

public class ScoreEntry
{
    //a single entry with name and score value
    public string? name {get;set;} = string.Empty;
    public int score {get;set;}
    
    [JsonConstructor]
    public ScoreEntry(){}
    
    public ScoreEntry(string _name, int _value)
    {
        name = _name;
        score = _value;
    }
}