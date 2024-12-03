using System.Text.RegularExpressions;

namespace TaskSphere;

public class UserInput
{
    public static string GetTaskName()
    {
        string? taskName;

        while (true)
        {
            Console.WriteLine("Please enter a name for your task.");
            taskName = Console.ReadLine();

            if (string.IsNullOrEmpty(taskName) || taskName.Length > 35)
                Console.WriteLine("The task name can not be empty.");
            else break;
        }

        return taskName;
    }

    
    public static string? GetTaskDeadline()
    {
        var datePattern = @"^\d{4}-\d{2}-\d{2}$";

        string? taskDeadline;
        while (true)
        {
            Console.WriteLine("Enter a deadline for your task (Optional).");
            taskDeadline = Console.ReadLine();


            if (string.IsNullOrEmpty(taskDeadline) || Regex.IsMatch(taskDeadline, datePattern)) break;

            Console.WriteLine("Invalid input. Make sure to use this date format 'yyyy-MM-dd'.");
        }

        return taskDeadline;
    }

    
    public static string? GetTaskDescription()
    {
        Console.WriteLine("Enter a description for your task (Optional).");

        string? taskDescription;
        while (true)
        {
            taskDescription = Console.ReadLine();

            if (taskDescription?.Length <= 255) break;

            Console.WriteLine("Invalid input.");
        }

        return taskDescription;
    }

    
    public static int GetCategoryId()
    {
        List<int> categories = [1, 2, 3];

        int category;
        while (true)
        {
            Console.WriteLine("Please enter task category.\n1 for 'Home'\n2 for 'Work'\n3 for 'Other'.");
            int.TryParse(Console.ReadLine(), out category);

            if (categories.Contains(category)) break;

            Console.WriteLine("Invalid input");
        }

        return category;
    }

    
    public static int GetTask(string connectionString)
    {
        var listOfTaskId = GetData.GetListOfTaskId(connectionString);

        int task;
        while (true)
        {
            Console.WriteLine("Please select a task to mark as complete by choosing it's number");
            GetData.DisplayTask(connectionString);

            int.TryParse(Console.ReadLine(), out task);

            if (listOfTaskId.Contains(task.ToString())) break;

            Console.WriteLine("Invalid input");
        }

        return task;
    }
}