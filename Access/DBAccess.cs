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
    
    public void PostScore(string userName, int value)
    {
        if((userName == null)||(userName.Length < 3))
        {
            Console.WriteLine("Warning. PostScore: username null or too short.");
            return;
        }
        //recieves score and name
        PostQuery(userName, value);
    }
    
    private void PostQuery(string userName, int value)
    {
        //new sql query: insert into table name + score
        SqliteConnection con = new SqliteConnection($"Data Source={PATH + FILE}");
        con.Open();
        SqliteCommand com = con.CreateCommand();
        //prepare sql template
        com.CommandText = "INSERT INTO TestData (name, score) VALUES (@param1, @param2)";
        //bind parameters
        com.Parameters.Add(new SqliteParameter("@param1", userName));
        com.Parameters.Add(new SqliteParameter("@param2", value));
        
        Console.Write("inserting into testData table. Result code: ");
        try {
            Console.WriteLine(com.ExecuteNonQuery());
        }
        catch (Exception e) {
            throw new Exception(e.Message);
        }
        con.Close();
        
    }
}