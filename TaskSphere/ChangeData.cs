using Microsoft.Data.SqlClient;

namespace TaskSphere;

public class ChangeData
{
    public static void CreateNewTask(string connectionString)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            var taskName = UserInput.GetTaskName();
            var taskDeadLine = UserInput.GetTaskDeadline();
            var taskDescription = UserInput.GetTaskDescription();
            var categoryId = UserInput.GetCategoryId();

            var query =
                "INSERT INTO Tasks (TaskName, TaskDeadline, TaskDescription, CategoryID) VALUES (@TaskName, @TaskDeadline, @TaskDescription, @CategoryID)";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TaskName", taskName);
                command.Parameters.AddWithValue("@TaskDeadline", taskDeadLine);
                command.Parameters.AddWithValue("@TaskDescription", taskDescription);
                command.Parameters.AddWithValue("@CategoryID", categoryId);

                command.ExecuteNonQuery();

                Console.WriteLine("Task created successfully.");
            }
        }
    }


    public static void SetTaskToComplete(string connectionString)
    {
        var taskId = UserInput.GetTask(connectionString);

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            var query = "UPDATE Tasks SET TaskStatus = 1 WHERE TaskID = @TaskID";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TaskID", taskId);

                var rowsAffected = command.ExecuteNonQuery();

                Console.WriteLine(rowsAffected > 0 ? "Task updated successfully." : "No task with matching ID found.");
            }
        }
    }
}