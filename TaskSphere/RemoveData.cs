using TaskSphere.Data;

namespace TaskSphere;

public class RemoveData
{
    public static void RemoveCategory()
    {
        using (var context = new TaskSphereContext())
        {
            var categoryToRemove = context.Categories
                .OrderBy(o => o.CategoryId)
                .LastOrDefault();

            if (categoryToRemove != null)
            {
                context.Categories.Remove(categoryToRemove);
                context.SaveChanges();

                Console.WriteLine("Category removed successfully.");
            }
            else
            {
                Console.WriteLine("No category with matching ID found.");
            }
        }
    }

    public static void RemoveTask()
    {
        using (var context = new TaskSphereContext())
        {
            var taskToRemove = context.Tasks
                .OrderBy(o => o.TaskId)
                .LastOrDefault();

            if (taskToRemove != null)
            {
                context.Tasks.Remove(taskToRemove);
                context.SaveChanges();

                Console.WriteLine("Task removed successfully");
            }
            else
            {
                Console.WriteLine("No task with matching ID found.");
            }
        }
    }
}