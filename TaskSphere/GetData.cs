using Microsoft.Data.SqlClient;

namespace TaskSphere;

public static class GetData
{
    public static void DisplayTaskAndCategoryName(string connectionString)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
                
            string query = "SELECT TaskName, CategoryName FROM Tasks JOIN Categories ON Tasks.CategoryID = Categories.CategoryID ORDER BY Tasks.CategoryID";
            using (var command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string? taskName = reader["TaskName"].ToString();
                        string? categoryName = reader["CategoryName"].ToString();
                
                        Console.WriteLine($"Task: {taskName}\nCategory: {categoryName}\n");
                    }
                }
            }
        }
    }
    
    
    public static void DisplayTask(string connectionString)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT TaskID, TaskName, TaskStatus FROM Tasks";

            using (var command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string? taskId = reader["TaskID"].ToString();
                        string? taskName = reader["TaskName"].ToString();
                        string? taskStatus = reader["TaskStatus"].ToString();

                        var currentStatus = taskStatus == "False" ? "Incomplete" : "Complete";

                        Console.WriteLine($"{taskId}. {taskName} : {currentStatus}");
                    }
                }
            }
        }
    }
    
    
    public static List<string?> GetListOfTaskId(string connectionString)
    {
        var listOfTaskId = new List<string?>();
            
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
                
            string query = "SELECT TaskID FROM Tasks";
            using (var command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string? taskId = reader["TaskID"].ToString();
                            
                        listOfTaskId.Add(taskId);
                    }
                }
            }
        }

        return listOfTaskId;
    }
}