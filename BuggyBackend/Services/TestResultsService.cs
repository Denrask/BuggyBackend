using Microsoft.Data.Sqlite;

public class TestResultsService
{
    private readonly string _connectionString;

    public TestResultsService(string connectionString)
    {
        _connectionString = connectionString;
        // Add native dependency
    }

    public IEnumerable<TestResult> GetTestResults(int page, int pageSize)
    {
        if (pageSize > 30)
            throw new ArgumentException("The pageSize should not be above 30.");
        var testResults = new List<TestResult>();
        var offset = (page - 1) * pageSize;
        
        var query = $"SELECT * FROM TestResults LIMIT {pageSize} OFFSET {offset}";

        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var command = new SqliteCommand(query, connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    testResults.Add(new TestResult
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        DeviceId = Convert.ToInt32(reader["DeviceId"]),
                        Verdict = reader["Verdict"].ToString(),
                        TestDuration = Convert.ToInt32(reader["TestDuration"]),
                        TestDate = DateTime.Parse(reader["TestDate"].ToString()),
                        OperatorName = reader["OperatorName"].ToString()
                    });
                }
            }
        }

        return testResults;
    }
}
