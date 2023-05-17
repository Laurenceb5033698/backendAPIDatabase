namespace DBScoreboard;

public class ScoreEntry
{
    //a single entry with name and score value
    public string name {get;set;}
    public int score {get;set;}
    
    public ScoreEntry(string _name, int _value)
    {
        name = _name;
        score = _value;
    }
}