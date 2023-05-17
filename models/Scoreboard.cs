namespace DBScoreboard;

public class Scoreboard{
    //scoreboard api object
    //holds 20 score entries
    public List<ScoreEntry> Board;
    
    public Scoreboard()
    {
        Board = new();
        //add data
    }
}