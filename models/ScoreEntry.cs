namespace DBScoreboard;

public class ScoreEntry
{
    //a single entry with name and score value
    string name;
    int score;
    
    public ScoreEntry(string _name, int _value)
    {
        name = _name;
        score = _value;
    }
}