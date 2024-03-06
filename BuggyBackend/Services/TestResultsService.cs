
using System;
using System.Collections.Generic;
using System.Data.SQLite;

public class TestResultsService
{
    private readonly string _connectionString;

    public TestResultsService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<TestResult> GetTestResults(int page, int pageSize)
    {
        var testResults = new List<TestResult>();
        var offset = (page - 1) * pageSize;
        
        var query = $"SELECT * FROM TestResults LIMIT {pageSize + 1} OFFSET {offset}";

        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            var command = new SQLiteCommand(query, connection);
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
