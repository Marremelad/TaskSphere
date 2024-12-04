using Microsoft.Data.SqlClient;
namespace TaskSphere;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TaskSphere;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        while(true)
        {
            Console.WriteLine("What do you want to do? \n 1. List all tasks \n 2. Create a new task \n 3. Complete a task \n 0. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Hämta och presentera alla kategorier med tillhörande uppgifter från databasen
                    ListTasks(connectionString);
                    break;
                case "2":
                    // Låt användaren lägg till nya uppgifter genom att mata in informationen om uppgiften
                    CreateTask(connectionString);
                    break;
                case "3":
                    // Låt användaren bocka av en uppgift som genomförd genom att uppge ID för uppgiften
                    CompleteTask(connectionString);
                    break;
                case "4":
                    // Dumt och roligt meddelande som inte spelar roll
                    Console.WriteLine("Accidentally inserted a virus in your SQL server. Oops!");
                    break;
                case "0":
                    // Stänger av programmet
                    return;
                default:
                    // När man gör ett ogiltigt val i menyn
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // Kollar upp motsvarande CategoryId baserat på CategoryName
    public static int? CheckCategoryId(string connectionString, string categoryName)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            // Öppna anslutningen
            connection.Open();

            // Hämta och presentera alla kategorier med tillhörande uppgifter från databasen
            string query = $"SELECT CategoryId FROM Categories WHERE CategoryName = @CategoryName";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CategoryName", categoryName);
                // Utför SQL-frågan
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Läs resultaten
                    while (reader.Read())
                    {
                        // Hämta kategori-id
                        int categoryId = Convert.ToInt32(reader["CategoryId"]);
                        return categoryId;
                    }
                }
            }
        }
        return null;
    }

    // Skapar en uppgift
    public static void CreateTask(string connectionString)
    {
        Console.WriteLine("Which task do you want to add?");

        Console.Write("Task: ");
        string taskName = Console.ReadLine();

        Console.Write("Task description: ");
        string taskDescription = Console.ReadLine();

        Console.Write("Deadline (in how many days from now): ");
        // Skapar ett DateTime-objekt som är baserat på dagens datum plus antalet dagar som användaren skriver in
        DateTime futureDate = DateTime.Now.AddDays(int.Parse(Console.ReadLine()));
        string taskDeadline = futureDate.ToString("yyyy-MM-dd");


        Console.Write("Category: ");
        string categoryName = Console.ReadLine();
        int? categoryId = CheckCategoryId(connectionString, categoryName);

        using (var connection = new SqlConnection(connectionString))
        {
            // Öppna anslutningen
            connection.Open();

            // Sätter in en rad i Tasks
            string sql = "INSERT INTO Tasks (TaskName, TaskStatus, TaskDeadline, TaskDescription, CategoryId) VALUES (@TaskName, 0, @TaskDeadline, @TaskDescription, @CategoryId)";

            // Utför SQL-frågan
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@TaskName", taskName);
                command.Parameters.AddWithValue("@TaskDescription", taskDescription);
                command.Parameters.AddWithValue("@TaskDeadline", taskDeadline);
                command.Parameters.AddWithValue("@CategoryId", categoryId);

                command.ExecuteNonQuery();
                Console.WriteLine($"Created {taskName} successfully.");
            }
        }
    }

    // Visar upp alla uppgifter
    public static void ListTasks(string connectionString)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            // Öppna anslutningen
            connection.Open();

            // Hämta och presentera alla kategorier med tillhörande uppgifter från databasen
            string query = "SELECT * FROM Tasks " +
                            "JOIN Categories ON Tasks.CategoryId = Categories.CategoryId " +
                            "ORDER BY Categories.CategoryId";

            using (var command = new SqlCommand(query, connection))
            {
                // Utför SQL-frågan
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Läs resultaten
                    while (reader.Read())
                    {
                        // Hämta kategori och uppgiftsbeskrivning
                        string category = reader["CategoryName"].ToString();
                        string taskName = reader["TaskName"].ToString();
                        string taskDescription = reader["TaskDescription"].ToString();
                        string taskDeadline = reader["TaskDeadline"].ToString();
                        string taskId = reader["TaskId"].ToString();

                        // Skriv ut kategori och uppgiftsbeskrivning
                        Console.WriteLine($"Category: {category}, Task: {taskName} - {taskDescription}, Deadline: {taskDeadline}, Task ID: {taskId}");
                    }
                }
            }
        }
    }

    // Bockar av en uppgift
    public static void CompleteTask(string connectionString)
    {
        Console.WriteLine("Which task have you completed?");

        Console.Write("Task ID: ");
        int taskId = int.Parse(Console.ReadLine());

        using (var connection = new SqlConnection(connectionString))
        {
            // Öppna anslutningen
            connection.Open();

            string sql = "UPDATE Tasks SET TaskStatus = 1 WHERE TaskId = @TaskId";

            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@TaskId", taskId);

                command.ExecuteNonQuery();
                Console.WriteLine($"Completed task with ID {taskId} successfully.");
            }
        }
    }
}