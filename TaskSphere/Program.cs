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
                    Data.ListTasks(connectionString);
                    break;
                case "2":
                    // Låt användaren lägg till nya uppgifter genom att mata in informationen om uppgiften
                    Data.CreateTask(connectionString);
                    break;
                case "3":
                    // Låt användaren bocka av en uppgift som genomförd genom att uppge ID för uppgiften
                    Data.CompleteTask(connectionString);
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
}