using TaskSphere.Data;
using TaskSphere.Models;
using Task = TaskSphere.Models.Task;

namespace TaskSphere;

public static class AddData
{
    public static void AddCategory()
    {
        using (var context = new TaskSphereContext())
        {
            var newCategory = new Category()
            {
                CategoryName = "New Category",
                CategoryDescription = "This is a new category"
            };

            context.Categories.Add(newCategory);
            context.SaveChanges();

            Console.WriteLine("New category added successfully.");
        }
    }

    public static void AddTask()
    {
        using (var context = new TaskSphereContext())
        {
            var newTask = new Task()
            {
                TaskName = "New Task",
                TaskDescription = "This is a new task",
                CategoryId = 3
            };

            context.Tasks.Add(newTask);
            context.SaveChanges();

            Console.WriteLine("New task added successfully.");
        }
    }
}