using Microsoft.Data.Sqlite;

namespace DBScoreboard;

public class AccessScoreboard
{
    //database connection for scoreboard database
    const string PATH = "../database/";
    const string FILE = "Scoreboard.db";
    
    public IEnumerable<ScoreEntry> GetScoreBoard()
    {
        List<ScoreEntry> board = new();
        Query(ref board);
        return board;
    }
    private void Query(ref List<ScoreEntry> data )
    {
        SqliteConnection con = new SqliteConnection($"Data Source={PATH + FILE}");
        con.Open();
        SqliteCommand com = con.CreateCommand();
        com.CommandText = "SELECT * FROM TestData ORDER BY score DESC LIMIT 20";
        using (SqliteDataReader reader = com.ExecuteReader())
        {
            while (reader.Read())
            {
                data.Add(new ScoreEntry(reader.GetString(1), reader.GetInt32(2)));
            }
        }
        con.Close();
    }
}